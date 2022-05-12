CREATE TABLE Portifolio ( 
        IdPortifolio INT IDENTITY(1,1) PRIMARY KEY, 
		TradeValue DECIMAL,
        ClientSector VARCHAR(255)
                );


CREATE TABLE Risk ( 
        IdRisk   INT IDENTITY(1,1) PRIMARY KEY, 
		IdPortifolio INT NOT NULL, 
		FOREIGN KEY (IdPortifolio) REFERENCES Portifolio(IdPortifolio),
		RiskDescription VARCHAR(255)      
                );




CREATE PROCEDURE dbo.risk_analysis
AS
BEGIN

DECLARE @id INT;
DECLARE @value INT;
DECLARE @clientSector   VARCHAR(255);

DECLARE cursor_loop cursor for
	  SELECT IdPortifolio, TradeValue, ClientSector         
      FROM Portifolio;


OPEN cursor_loop;

FETCH NEXT FROM cursor_loop into @id, @value, @clientSector;

WHILE @@FETCH_STATUS = 0
	BEGIN 

	if @value > 1000000 and @clientSector = 'Private'   
INSERT INTO Risk (IdPortifolio, RiskDescription) values (@id, 'HIGHRISK') 

else if @value > 1000000 and @clientSector = 'Public' 
INSERT INTO Risk (IdPortifolio, RiskDescription) values (@id, 'MEDIUMRISK') 

else 
	INSERT INTO Risk (IdPortifolio, RiskDescription) values (@id, 'LOWRISK') 

FETCH NEXT FROM cursor_loop into @id, @value, @clientSector;

	END;

CLOSE cursor_loop;
DEALLOCATE cursor_loop;

END;




