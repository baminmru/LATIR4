DELIMITER $$

CREATE DEFINER=`root`@`localhost` FUNCTION `B2G`(
    $Data BINARY(16)
) RETURNS char(38) CHARSET utf8
    DETERMINISTIC
BEGIN
    DECLARE $Result CHAR(38) DEFAULT NULL;
    IF $Data IS NOT NULL THEN
        SET $Result = CONCAT('{',HEX(SUBSTRING($Data,4,1)),HEX(SUBSTRING($Data,3,1)),HEX(SUBSTRING($Data,2,1)), HEX(SUBSTRING($Data,1,1)) , '-', 
                HEX(SUBSTRING($Data,6,1)),HEX(SUBSTRING($Data,5,1)),'-',
                HEX(SUBSTRING($Data,8,1)) , HEX(SUBSTRING($Data,7,1)),'-',
                HEX(SUBSTRING($Data,9,2)),'-',HEX(SUBSTRING($Data,11,6)) ,'}');
        SET $Result = UCASE($Result);
    END IF;
    RETURN $Result;
END
$$

CREATE DEFINER=`root`@`localhost` FUNCTION `G2B`(
    $Data VARCHAR(36)
) RETURNS binary(16)
    DETERMINISTIC
BEGIN
    DECLARE $Result BINARY(16) DEFAULT NULL;
    IF $Data IS NOT NULL THEN
    
        SET $Data = REPLACE($Data,'-','');
        SET $Data = REPLACE($Data,'{','');
        SET $Data = REPLACE($Data,'}','');
        SET $Result = CONCAT(UNHEX(SUBSTRING($Data,7,2)),UNHEX(SUBSTRING($Data,5,2)),UNHEX(SUBSTRING($Data,3,2)), UNHEX(SUBSTRING($Data,1,2)),
                UNHEX(SUBSTRING($Data,11,2)),UNHEX(SUBSTRING($Data,9,2)),UNHEX(SUBSTRING($Data,15,2)) , UNHEX(SUBSTRING($Data,13,2)),
                UNHEX(SUBSTRING($Data,17,16)));
    END IF;
    RETURN $Result;
END
