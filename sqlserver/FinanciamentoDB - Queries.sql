-- Listar todos os clientes do estado de SP que tenham mais de 60% das parcelas pagas.	
SELECT 
	C.IdCliente,
	C.Nome,
	'(' + Cel.CodigoArea + ') ' + Cel.NumeroCelular AS 'Celular',
	UF.NomeEstado AS 'Estado'
FROM Parcela AS P 
INNER JOIN Financiamento AS F ON F.IdFinanciamento = P.IdFinanciamento
INNER JOIN Cliente AS C ON C.IdCliente = F.IdCliente
INNER JOIN Celular AS Cel ON Cel.IdCliente = C.IdCliente
INNER JOIN UF ON UF.IdUF = C.IdUF
WHERE UF.SiglaEstado = 'SP'
GROUP BY C.IdCliente, C.Nome, Cel.CodigoArea, Cel.NumeroCelular, UF.NomeEstado 
HAVING (COUNT(P.IdFinanciamento) * 0.6) < COUNT(P.DataPagamento);

-- Listar os primeiros 4 clientes que tenham alguma parcela com mais de 05 dias atrasadas
SELECT DISTINCT
	TOP 4 
	C.IdCliente,
	C.Nome,
	'(' + Cel.CodigoArea + ') ' + Cel.NumeroCelular AS 'Celular',
	UF.NomeEstado AS 'Estado'
FROM Cliente AS C
	INNER JOIN Celular AS Cel ON Cel.IdCliente = C.IdCliente
	INNER JOIN UF ON UF.IdUF = C.IdUF
	INNER JOIN Financiamento AS F ON F.IdCliente = C.IdCliente
	INNER JOIN Parcela AS P ON P.IdFinanciamento = F.IdFinanciamento
WHERE (P.DataPagamento IS NULL
	AND DATEDIFF(day, P.DataVencimento, GETDATE()) > 5) 
	OR (P.DataPagamento IS NOT NULL AND DATEDIFF(day, P.DataVencimento, P.DataPagamento) > 5);

-- Listar todos os clientes que já atrasaram em algum momento duas ou mais parcelas em mais de 10 dias, e que o valor do financiamento seja maior que R$ 10.000,00.
SELECT
	C.IdCliente,
	C.Nome,
	'(' + Cel.CodigoArea + ') ' + Cel.NumeroCelular AS 'Celular',
	UF.NomeEstado AS 'Estado'
FROM Cliente AS C
	INNER JOIN Celular AS Cel ON Cel.IdCliente = C.IdCliente
	INNER JOIN UF ON UF.IdUF = C.IdUF
	INNER JOIN Financiamento AS F ON F.IdCliente = C.IdCliente
	INNER JOIN Parcela AS P ON P.IdFinanciamento = F.IdFinanciamento
WHERE (F.ValorTotal > 10000.00
	AND DATEDIFF(day, P.DataVencimento, P.DataPagamento) > 10)
GROUP BY C.IdCliente, C.Nome, Cel.CodigoArea, Cel.NumeroCelular, UF.NomeEstado 
HAVING COUNT(*) >= 2;


