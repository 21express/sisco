-- --------------------------------------------------------------------------------
-- Routine DDL
-- Note: comments before and after the routine body will not be stored by the server
-- --------------------------------------------------------------------------------
DELIMITER $$

CREATE DEFINER=`root`@`127.0.0.1` FUNCTION `SLA`(from_date DATETIME, to_date DATETIME) RETURNS int(11)
    READS SQL DATA
    DETERMINISTIC
BEGIN
	/*** previous code. try to improve query
	DECLARE _diff INT;
	DECLARE _sla INT;
	DECLARE _dayname VARCHAR(20);
	DECLARE _holiday BIT(1);

	SET _sla = 0;
	
	
	sloop:LOOP

		SELECT UPPER(DAYNAME(from_date)) INTO _dayname;
		SELECT 1 INTO _holiday FROM siscodb.holiday WHERE `date` = from_date;

		IF _dayname = UPPER('sunday') OR _holiday = 1 THEN
			SET from_date = DATE_ADD(from_date, INTERVAL 1 DAY);
		END IF;

		SET _diff = DATEDIFF(to_date, from_date);
		IF _diff = 1 THEN RETURN _diff; END IF;
		IF _diff < 0 THEN RETURN 0; END IF;
		IF _diff = 0 THEN
			RETURN _sla;
			LEAVE sloop;
		ELSE
			SET from_date = DATE_ADD(from_date, INTERVAL 1 DAY);
			SET _sla = _sla + 1;
		END IF;

	END LOOP sloop;
	***/
	
	DECLARE _sunday INT;
	DECLARE _holiday INT;
	DECLARE _sla INT;
	DECLARE _holyday_on_sunday INT;

	SET _sunday = 0;
	SET _holiday = 0;
	SET _sla = 0;
	SET _holyday_on_sunday = 0;
	
	SET _sla = DATEDIFF(to_date, from_date);
	SELECT COUNT(*) INTO _holiday FROM siscodb.holiday WHERE DATE >= from_date and DATE <= to_date;

	SELECT COUNT(*) INTO _holyday_on_sunday FROM (
		SELECT DAYNAME(date) dayname FROM siscodb.holiday WHERE date >= from_date AND date <= to_date
	) t
	WHERE dayname = 'Sunday';

	SET _holiday = _holiday - _holyday_on_sunday;
	
	SELECT
		countDay INTO _sunday
	FROM (
		SELECT
			DAYNAME(DATE_ADD(from_date, INTERVAL (Units.i + Tens.i * 10 + Hundreds.i * 100) DAY)) AS aDayOfWeek,
			COUNT(*) countDay
		FROM (
			SELECT 0 AS i UNION 
			SELECT 1 UNION 
			SELECT 2 UNION 
			SELECT 3 UNION 
			SELECT 4 UNION 
			SELECT 5 UNION 
			SELECT 6 UNION 
			SELECT 7 UNION 
			SELECT 8 UNION 
			SELECT 9
		) AS Units
		CROSS JOIN (
			SELECT 0 AS i UNION 
			SELECT 1 UNION 
			SELECT 2 UNION 
			SELECT 3 UNION 
			SELECT 4 UNION 
			SELECT 5 UNION 
			SELECT 6 UNION 
			SELECT 7 UNION 
			SELECT 8 UNION 
			SELECT 9
		) AS Tens
		CROSS JOIN (
			SELECT 0 AS i UNION 
			SELECT 1 UNION 
			SELECT 2 UNION 
			SELECT 3 UNION 
			SELECT 4 UNION 
			SELECT 5 UNION 
			SELECT 6 UNION 
			SELECT 7 UNION 
			SELECT 8 UNION 
			SELECT 9
		) AS Hundreds
		WHERE DATE_ADD(from_date, INTERVAL (Units.i + Tens.i * 10 + Hundreds.i * 100) DAY) <= to_date
		GROUP BY aDayOfWeek
	) Calendar
	WHERE aDayOfWeek = 'Sunday';

	SET _sla = _sla - _holiday - _sunday;
RETURN _sla;
END