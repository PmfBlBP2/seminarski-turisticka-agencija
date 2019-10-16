-- MySQL Workbench Forward Engineering

SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0;
SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0;
SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='ONLY_FULL_GROUP_BY,STRICT_TRANS_TABLES,NO_ZERO_IN_DATE,NO_ZERO_DATE,ERROR_FOR_DIVISION_BY_ZERO,NO_ENGINE_SUBSTITUTION';

-- -----------------------------------------------------
-- Schema turisticka_agencija
-- -----------------------------------------------------

-- -----------------------------------------------------
-- Schema turisticka_agencija
-- -----------------------------------------------------
CREATE SCHEMA IF NOT EXISTS `turisticka_agencija` DEFAULT CHARACTER SET utf8 ;
USE `turisticka_agencija` ;

-- -----------------------------------------------------
-- Table `turisticka_agencija`.`drzava`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `turisticka_agencija`.`drzava` ;

CREATE TABLE IF NOT EXISTS `turisticka_agencija`.`drzava` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Naziv` VARCHAR(1024) NOT NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB
AUTO_INCREMENT = 14
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `turisticka_agencija`.`destinacija`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `turisticka_agencija`.`destinacija` ;

CREATE TABLE IF NOT EXISTS `turisticka_agencija`.`destinacija` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `DrzavaId` INT(11) NOT NULL,
  `Grad` VARCHAR(1024) NOT NULL,
  `Opis` VARCHAR(10000) NULL DEFAULT NULL,
  `Slika` VARCHAR(10000) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `DestinacijaId_UNIQUE` (`Id` ASC),
  INDEX `fk_destinacija_drzava1_idx` (`DrzavaId` ASC),
  CONSTRAINT `fk_destinacija_drzava1`
    FOREIGN KEY (`DrzavaId`)
    REFERENCES `turisticka_agencija`.`drzava` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
AUTO_INCREMENT = 3
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `turisticka_agencija`.`korisnik`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `turisticka_agencija`.`korisnik` ;

CREATE TABLE IF NOT EXISTS `turisticka_agencija`.`korisnik` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `Ime` VARCHAR(1024) NOT NULL,
  `Prezime` VARCHAR(1024) NOT NULL,
  `DatumRodjenja` DATE NOT NULL,
  `Email` VARCHAR(1024) NULL DEFAULT NULL,
  `BrojTelefona` VARCHAR(45) NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `Id_UNIQUE` (`Id` ASC))
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `turisticka_agencija`.`kompanija`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `turisticka_agencija`.`kompanija` ;

CREATE TABLE IF NOT EXISTS `turisticka_agencija`.`kompanija` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Naziv` VARCHAR(1024) NOT NULL,
  `Grad` VARCHAR(1024) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `turisticka_agencija`.`tip_prevoza`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `turisticka_agencija`.`tip_prevoza` ;

CREATE TABLE IF NOT EXISTS `turisticka_agencija`.`tip_prevoza` (
  `Id` INT NOT NULL AUTO_INCREMENT,
  `Naziv` VARCHAR(1024) NULL,
  PRIMARY KEY (`Id`))
ENGINE = InnoDB;


-- -----------------------------------------------------
-- Table `turisticka_agencija`.`prevoz`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `turisticka_agencija`.`prevoz` ;

CREATE TABLE IF NOT EXISTS `turisticka_agencija`.`prevoz` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `KompanijaId` INT NOT NULL,
  `TipPrevozaId` INT NOT NULL,
  `Opis` VARCHAR(10000) NULL DEFAULT NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_prevoz_kompanija1_idx` (`KompanijaId` ASC),
  INDEX `fk_prevoz_tip_prevoza1_idx` (`TipPrevozaId` ASC),
  CONSTRAINT `fk_prevoz_kompanija1`
    FOREIGN KEY (`KompanijaId`)
    REFERENCES `turisticka_agencija`.`kompanija` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_prevoz_tip_prevoza1`
    FOREIGN KEY (`TipPrevozaId`)
    REFERENCES `turisticka_agencija`.`tip_prevoza` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `turisticka_agencija`.`smjestaj`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `turisticka_agencija`.`smjestaj` ;

CREATE TABLE IF NOT EXISTS `turisticka_agencija`.`smjestaj` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `DestinacijaId` INT(11) NOT NULL,
  `Naziv` VARCHAR(1024) NOT NULL,
  `Opis` VARCHAR(10000) NULL DEFAULT NULL,
  `Adresa` VARCHAR(1024) NULL DEFAULT NULL,
  `Slika` VARCHAR(3000) NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_smjestaj_destinacija1_idx` (`DestinacijaId` ASC),
  CONSTRAINT `fk_smjestaj_destinacija1`
    FOREIGN KEY (`DestinacijaId`)
    REFERENCES `turisticka_agencija`.`destinacija` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `turisticka_agencija`.`ponuda`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `turisticka_agencija`.`ponuda` ;

CREATE TABLE IF NOT EXISTS `turisticka_agencija`.`ponuda` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `SmjestajId` INT(11) NOT NULL,
  `DestinacijaId` INT(11) NOT NULL,
  `PrevozId` INT(11) NOT NULL,
  `Naziv` VARCHAR(1024) NOT NULL,
  `DatumKreiranja` DATE NOT NULL,
  `Pocetak` DATE NOT NULL,
  `Kraj` DATE NOT NULL,
  `Cijena` DECIMAL(10,2) NOT NULL,
  `BrojMijesta` INT NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE INDEX `IdPutovanja_UNIQUE` (`Id` ASC),
  INDEX `fk_ponuda_smjestaj1_idx` (`SmjestajId` ASC),
  INDEX `fk_ponuda_destinacija1_idx` (`DestinacijaId` ASC),
  INDEX `fk_ponuda_prevoz1_idx` (`PrevozId` ASC),
  CONSTRAINT `fk_ponuda_destinacija1`
    FOREIGN KEY (`DestinacijaId`)
    REFERENCES `turisticka_agencija`.`destinacija` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ponuda_prevoz1`
    FOREIGN KEY (`PrevozId`)
    REFERENCES `turisticka_agencija`.`prevoz` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_ponuda_smjestaj1`
    FOREIGN KEY (`SmjestajId`)
    REFERENCES `turisticka_agencija`.`smjestaj` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


-- -----------------------------------------------------
-- Table `turisticka_agencija`.`rezervacija`
-- -----------------------------------------------------
DROP TABLE IF EXISTS `turisticka_agencija`.`rezervacija` ;

CREATE TABLE IF NOT EXISTS `turisticka_agencija`.`rezervacija` (
  `Id` INT(11) NOT NULL AUTO_INCREMENT,
  `PonudaId` INT(11) NOT NULL,
  `KorisnikId` INT(11) NOT NULL,
  `DatumRezervacije` DATETIME NULL,
  `Iznos` DECIMAL(10,2) NULL,
  PRIMARY KEY (`Id`),
  INDEX `fk_rezervacija_ponuda1_idx` (`PonudaId` ASC),
  INDEX `fk_rezervacija_korisnik1_idx` (`KorisnikId` ASC),
  CONSTRAINT `fk_rezervacija_ponuda1`
    FOREIGN KEY (`PonudaId`)
    REFERENCES `turisticka_agencija`.`ponuda` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION,
  CONSTRAINT `fk_rezervacija_korisnik1`
    FOREIGN KEY (`KorisnikId`)
    REFERENCES `turisticka_agencija`.`korisnik` (`Id`)
    ON DELETE NO ACTION
    ON UPDATE NO ACTION)
ENGINE = InnoDB
DEFAULT CHARACTER SET = utf8;


SET SQL_MODE=@OLD_SQL_MODE;
SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS;
SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS;
