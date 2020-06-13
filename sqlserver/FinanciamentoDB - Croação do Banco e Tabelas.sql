GO
USE master;
DROP DATABASE FinanciamentoDB;
GO
CREATE DATABASE FinanciamentoDB;
GO
USE FinanciamentoDB;



CREATE TABLE TipoFinanciamento
(
	IdTipoFinanciamento BIGINT IDENTITY PRIMARY KEY,
	Descricao NVARCHAR(50) NOT NULL
);

CREATE TABLE UF
(
	IdUF BIGINT IDENTITY PRIMARY KEY,
	NomeEstado NVARCHAR(20) NOT NULL,
	SiglaEstado NVARCHAR(2) NOT NULL
);

CREATE TABLE Celular
(
	IdCelular BIGINT IDENTITY PRIMARY KEY,
	CodigoArea CHAR(2) NOT NULL,
	NumeroCelular NCHAR(9) NOT NULL,
	IdCliente BIGINT NOT NULL
);

CREATE TABLE Cliente 
(
	IdCliente BIGINT IDENTITY PRIMARY KEY,
	Nome NVARCHAR(250) NOT NULL,
	IdUF BIGINT NOT NULL	
);


CREATE TABLE Financiamento
(
	IdFinanciamento BIGINT IDENTITY PRIMARY KEY,
	ValorTotal MONEY NOT NULL,
	DataVencimento DATETIME NOT NULL,
	IdCliente BIGINT NOT NULL,
	IdTipoFinanciamento BIGINT NOT NULL
);


CREATE TABLE Parcela
(
	IdParcela BIGINT IDENTITY PRIMARY KEY,
	NumeroParcela TINYINT NOT NULL,
	ValorParcela MONEY NOT NULL,	
	DataVencimento DATETIME NOT NULL,	
	DataPagamento DATETIME NULL,
	IdFinanciamento BIGINT NOT NULL
);



ALTER TABLE dbo.Cliente ADD CONSTRAINT FK_Cliente_UF FOREIGN KEY (IdUf) REFERENCES dbo.UF (IdUf);
ALTER TABLE dbo.Celular ADD CONSTRAINT FK_Celular_Cliente FOREIGN KEY (IdCliente) REFERENCES dbo.Cliente (IdCliente);
ALTER TABLE dbo.Financiamento ADD CONSTRAINT FK_Financiamento_Cliente FOREIGN KEY (IdCliente) REFERENCES dbo.Cliente (IdCliente);
ALTER TABLE dbo.Financiamento ADD CONSTRAINT FK_Financiamento_TipoFinanciamento FOREIGN KEY (IdTipoFinanciamento) REFERENCES dbo.TipoFinanciamento (IdTipoFinanciamento);
ALTER TABLE dbo.Parcela ADD CONSTRAINT FK_Parcela_Financiamento FOREIGN KEY (IdFinanciamento) REFERENCES dbo.Financiamento (IdFinanciamento);