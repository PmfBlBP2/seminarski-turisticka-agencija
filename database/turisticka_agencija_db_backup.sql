CREATE DATABASE  IF NOT EXISTS `turisticka_agencija` /*!40100 DEFAULT CHARACTER SET utf8 */;
USE `turisticka_agencija`;
-- MySQL dump 10.13  Distrib 5.7.25, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: turisticka_agencija
-- ------------------------------------------------------
-- Server version	5.5.5-10.1.36-MariaDB

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `destinacija`
--

DROP TABLE IF EXISTS `destinacija`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `destinacija` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DrzavaId` int(11) NOT NULL,
  `Grad` varchar(1024) NOT NULL,
  `Opis` varchar(10000) DEFAULT NULL,
  `Slika` varchar(10000) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `DestinacijaId_UNIQUE` (`Id`),
  KEY `fk_destinacija_drzava1_idx` (`DrzavaId`),
  CONSTRAINT `fk_destinacija_drzava1` FOREIGN KEY (`DrzavaId`) REFERENCES `drzava` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `destinacija`
--
-- ORDER BY:  `Id`

LOCK TABLES `destinacija` WRITE;
/*!40000 ALTER TABLE `destinacija` DISABLE KEYS */;
INSERT INTO `destinacija` (`Id`, `DrzavaId`, `Grad`, `Opis`, `Slika`) VALUES (1,6,'Beč','Beč leži u sjeveroistočnom dijelu Austrije, između Alpa i Karpata, gdje je Dunav probio svoj put prema moru kroz planine.','https://storage.radiosarajevo.ba/image/426112/1180x732/bec-panorama-grada-15.jpg'),(2,8,'Pariz','Pariz je prestonica i najveći grad Francuske. Nalazi se na severu Francuske na reci Seni.','https://www.turizamiputovanja.com/wp-content/uploads/2017/01/Pariz-no%C4%87u.jpg'),(3,1,'Banja Luka','Smješten na obali Vrbasa, vrlo fin. Sve preporuke.','http://www.banjaluka-tourism.banjaluka-turizam.com/images/Magical-City-No.3.jpg');
/*!40000 ALTER TABLE `destinacija` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `drzava`
--

DROP TABLE IF EXISTS `drzava`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `drzava` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Naziv` varchar(1024) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=14 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `drzava`
--
-- ORDER BY:  `Id`

LOCK TABLES `drzava` WRITE;
/*!40000 ALTER TABLE `drzava` DISABLE KEYS */;
INSERT INTO `drzava` (`Id`, `Naziv`) VALUES (1,'Bosna i Hercegovina'),(2,'Srbija'),(3,'Hrvatska'),(4,'Crna Gora'),(5,'Švajcarska'),(6,'Austrija'),(7,'Španija'),(8,'Francuska'),(9,'Rusija'),(10,'Kina'),(11,'Japan'),(12,'Sjedinjene Američke Države'),(13,'Velika Britanija');
/*!40000 ALTER TABLE `drzava` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `kompanija`
--

DROP TABLE IF EXISTS `kompanija`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `kompanija` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Naziv` varchar(1024) NOT NULL,
  `Grad` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=8 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `kompanija`
--
-- ORDER BY:  `Id`

LOCK TABLES `kompanija` WRITE;
/*!40000 ALTER TABLE `kompanija` DISABLE KEYS */;
INSERT INTO `kompanija` (`Id`, `Naziv`, `Grad`) VALUES (1,'Lasta','Beograd'),(2,'Golub','Kotor Varoš'),(3,'Tempoturist','Teslić'),(4,'Neobas','Banja Luka'),(5,'AirSerbia','Beograd'),(6,'WizzAir','Budimpešta'),(7,'RyanAir','Dablin');
/*!40000 ALTER TABLE `kompanija` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `korisnik`
--

DROP TABLE IF EXISTS `korisnik`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `korisnik` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Ime` varchar(1024) NOT NULL,
  `Prezime` varchar(1024) NOT NULL,
  `Email` varchar(1024) DEFAULT NULL,
  `DatumRodjenja` date NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Id_UNIQUE` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `korisnik`
--
-- ORDER BY:  `Id`

LOCK TABLES `korisnik` WRITE;
/*!40000 ALTER TABLE `korisnik` DISABLE KEYS */;
INSERT INTO `korisnik` (`Id`, `Ime`, `Prezime`, `Email`, `DatumRodjenja`) VALUES (1,'Aleksandar','Toprek','aleksandartoprek@gmail.com','1995-07-29'),(2,'Tanja','Gromilic','tanjagromilic@gmail.com','1996-05-08'),(3,'Nikolina','Čolić','nikolinacolic@gmail.com','1995-09-08'),(4,'Đorđe','Simeunčević','djordjes@gmail.com','1995-05-19');
/*!40000 ALTER TABLE `korisnik` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `ponuda`
--

DROP TABLE IF EXISTS `ponuda`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `ponuda` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `SmjestajId` int(11) NOT NULL,
  `DestinacijaId` int(11) NOT NULL,
  `PrevozId` int(11) NOT NULL,
  `Naziv` varchar(1024) NOT NULL,
  `DatumKreiranja` date NOT NULL,
  `Pocetak` date NOT NULL,
  `Kraj` date NOT NULL,
  `Cijena` decimal(10,2) NOT NULL,
  `BrojMijesta` int(11) NOT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `IdPutovanja_UNIQUE` (`Id`),
  KEY `fk_ponuda_smjestaj1_idx` (`SmjestajId`),
  KEY `fk_ponuda_destinacija1_idx` (`DestinacijaId`),
  KEY `fk_ponuda_prevoz1_idx` (`PrevozId`),
  CONSTRAINT `fk_ponuda_destinacija1` FOREIGN KEY (`DestinacijaId`) REFERENCES `destinacija` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ponuda_prevoz1` FOREIGN KEY (`PrevozId`) REFERENCES `prevoz` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_ponuda_smjestaj1` FOREIGN KEY (`SmjestajId`) REFERENCES `smjestaj` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `ponuda`
--
-- ORDER BY:  `Id`

LOCK TABLES `ponuda` WRITE;
/*!40000 ALTER TABLE `ponuda` DISABLE KEYS */;
INSERT INTO `ponuda` (`Id`, `SmjestajId`, `DestinacijaId`, `PrevozId`, `Naziv`, `DatumKreiranja`, `Pocetak`, `Kraj`, `Cijena`, `BrojMijesta`) VALUES (1,1,2,3,'Nova godina u Parizu','2019-10-08','2019-12-25','2020-01-05',1350.00,0),(2,2,1,2,'Advent u Beču','2019-10-08','2019-12-20','2019-12-24',430.00,0),(3,3,3,1,'Vikend u Banjoj Luci','2019-10-15','2019-10-25','2019-10-27',55.50,0);
/*!40000 ALTER TABLE `ponuda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `prevoz`
--

DROP TABLE IF EXISTS `prevoz`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `prevoz` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `KompanijaId` int(11) NOT NULL,
  `TipPrevozaId` int(11) NOT NULL,
  `Opis` varchar(10000) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_prevoz_kompanija1_idx` (`KompanijaId`),
  KEY `fk_prevoz_tip_prevoza1_idx` (`TipPrevozaId`),
  CONSTRAINT `fk_prevoz_kompanija1` FOREIGN KEY (`KompanijaId`) REFERENCES `kompanija` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_prevoz_tip_prevoza1` FOREIGN KEY (`TipPrevozaId`) REFERENCES `tip_prevoza` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `prevoz`
--
-- ORDER BY:  `Id`

LOCK TABLES `prevoz` WRITE;
/*!40000 ALTER TABLE `prevoz` DISABLE KEYS */;
INSERT INTO `prevoz` (`Id`, `KompanijaId`, `TipPrevozaId`, `Opis`) VALUES (1,1,1,'Visokoturistički autobus'),(2,2,1,'Autobus na sprat'),(3,5,2,'Airbus A-320'),(4,6,2,'Charter let');
/*!40000 ALTER TABLE `prevoz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rezervacija`
--

DROP TABLE IF EXISTS `rezervacija`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rezervacija` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `PonudaId` int(11) NOT NULL,
  `BrojOsoba` int(11) DEFAULT NULL,
  `Iznos` decimal(10,0) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_rezervacija_ponuda1_idx` (`PonudaId`),
  CONSTRAINT `fk_rezervacija_ponuda1` FOREIGN KEY (`PonudaId`) REFERENCES `ponuda` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rezervacija`
--
-- ORDER BY:  `Id`

LOCK TABLES `rezervacija` WRITE;
/*!40000 ALTER TABLE `rezervacija` DISABLE KEYS */;
INSERT INTO `rezervacija` (`Id`, `PonudaId`, `BrojOsoba`, `Iznos`) VALUES (1,1,2,NULL);
/*!40000 ALTER TABLE `rezervacija` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `rezervacija_korisnici`
--

DROP TABLE IF EXISTS `rezervacija_korisnici`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `rezervacija_korisnici` (
  `RezervacijaId` int(11) NOT NULL,
  `KorisnikId` int(11) NOT NULL,
  `DatumRezervacije` date DEFAULT NULL,
  PRIMARY KEY (`RezervacijaId`,`KorisnikId`),
  KEY `fk_rezervacija_korisnici_rezervacija1_idx` (`RezervacijaId`),
  KEY `fk_rezervacija_korisnici_korisnik1_idx` (`KorisnikId`),
  CONSTRAINT `fk_rezervacija_korisnici_korisnik1` FOREIGN KEY (`KorisnikId`) REFERENCES `korisnik` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION,
  CONSTRAINT `fk_rezervacija_korisnici_rezervacija1` FOREIGN KEY (`RezervacijaId`) REFERENCES `rezervacija` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `rezervacija_korisnici`
--
-- ORDER BY:  `RezervacijaId`,`KorisnikId`

LOCK TABLES `rezervacija_korisnici` WRITE;
/*!40000 ALTER TABLE `rezervacija_korisnici` DISABLE KEYS */;
INSERT INTO `rezervacija_korisnici` (`RezervacijaId`, `KorisnikId`, `DatumRezervacije`) VALUES (1,1,'2019-10-15'),(1,2,'2019-10-14');
/*!40000 ALTER TABLE `rezervacija_korisnici` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `smjestaj`
--

DROP TABLE IF EXISTS `smjestaj`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `smjestaj` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `DestinacijaId` int(11) NOT NULL,
  `Naziv` varchar(1024) NOT NULL,
  `Opis` varchar(10000) DEFAULT NULL,
  `Adresa` varchar(1024) DEFAULT NULL,
  `Slika` varchar(3000) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `fk_smjestaj_destinacija1_idx` (`DestinacijaId`),
  CONSTRAINT `fk_smjestaj_destinacija1` FOREIGN KEY (`DestinacijaId`) REFERENCES `destinacija` (`Id`) ON DELETE NO ACTION ON UPDATE NO ACTION
) ENGINE=InnoDB AUTO_INCREMENT=4 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `smjestaj`
--
-- ORDER BY:  `Id`

LOCK TABLES `smjestaj` WRITE;
/*!40000 ALTER TABLE `smjestaj` DISABLE KEYS */;
INSERT INTO `smjestaj` (`Id`, `DestinacijaId`, `Naziv`, `Opis`, `Adresa`, `Slika`) VALUES (1,2,'Four Seasons Hotel George V','Hotel obuhvata vrhunske spa tretmane, restorane nagrađene Mišlenovim zvezdicama i privatne terase sa veličanstvenim pogledom na Pariz.','31 Avenue George V',NULL),(2,1,'Sofie Apartments','Apartmani Sofie se nalaze na 5 minuta vožnje od Katedrale Sv. Stefana i na 5 minuta hoda od Bulevara Ring.','Kegelgasse 20',NULL),(3,3,'Villa Maria','Luksuzno opremljena villa nedaleko od centra grada.','Svetog Save 24',NULL);
/*!40000 ALTER TABLE `smjestaj` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `tip_prevoza`
--

DROP TABLE IF EXISTS `tip_prevoza`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `tip_prevoza` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Naziv` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `tip_prevoza`
--
-- ORDER BY:  `Id`

LOCK TABLES `tip_prevoza` WRITE;
/*!40000 ALTER TABLE `tip_prevoza` DISABLE KEYS */;
INSERT INTO `tip_prevoza` (`Id`, `Naziv`) VALUES (1,'Autobus'),(2,'Avion'),(3,'Voz'),(4,'Brod');
/*!40000 ALTER TABLE `tip_prevoza` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping events for database 'turisticka_agencija'
--

--
-- Dumping routines for database 'turisticka_agencija'
--
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2019-10-15 15:30:22
