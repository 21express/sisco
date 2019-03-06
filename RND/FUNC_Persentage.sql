CREATE DEFINER=`root`@`localhost` FUNCTION `Percentage`(v1 DECIMAL, v2 DECIMAL) RETURNS float(10,1)
BEGIN
	DECLARE _diff DECIMAL;
    DECLARE _percent Float;
    
	IF v1 >= v2 THEN
		SET _diff = v1 - v2;
        IF _diff > 0 THEN
			SET _percent = (_diff / v1) * 100;
		ELSE
			SET _percent = 0;
        END IF;
	ELSE
		SET _diff = v2 - v1;
        IF _diff > 0 THEN
			SET _percent = (_diff / v2) * -100;
		ELSE
			SET _percent = 0;
		END IF;
    END IF;
    
	RETURN _percent;
END