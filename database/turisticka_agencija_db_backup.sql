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
-- Dumping data for table `destinacija`
--
-- ORDER BY:  `Id`

LOCK TABLES `destinacija` WRITE;
/*!40000 ALTER TABLE `destinacija` DISABLE KEYS */;
INSERT INTO `destinacija` (`Id`, `DrzavaId`, `Grad`, `Opis`, `Slika`) VALUES (1,6,'Beč','Beč leži u sjeveroistočnom dijelu Austrije, između Alpa i Karpata, gdje je Dunav probio svoj put prema moru kroz planine. Grad leži pretežno sa desne obale rijeke, sve do obronaka Kahlenberga.','https://storage.radiosarajevo.ba/image/426112/1180x732/bec-panorama-grada-15.jpg'),(2,8,'Pariz','Pariz je prestonica i najveći grad Francuske. Nalazi se na severu Francuske na reci Seni.','https://www.turizamiputovanja.com/wp-content/uploads/2017/01/Pariz-no%C4%87u.jpg'),(3,1,'Banja Luka','Smjesten na obali Vrbasa, vrlo fin. Sve preporuke.','http://www.banjaluka-tourism.banjaluka-turizam.com/images/Magical-City-No.3.jpg');
/*!40000 ALTER TABLE `destinacija` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `kompanija`
--
-- ORDER BY:  `Id`

LOCK TABLES `kompanija` WRITE;
/*!40000 ALTER TABLE `kompanija` DISABLE KEYS */;
INSERT INTO `kompanija` (`Id`, `Naziv`, `Grad`) VALUES (1,'Lasta','Beograd'),(2,'Golub','Kotor Varoš'),(3,'Tempoturist','Teslić'),(4,'Neobas','Banja Luka'),(5,'AirSerbia','Beograd'),(6,'WizzAir','Budimpešta'),(7,'RyanAir','Dablin');
/*!40000 ALTER TABLE `kompanija` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `ponuda`
--
-- ORDER BY:  `Id`

LOCK TABLES `ponuda` WRITE;
/*!40000 ALTER TABLE `ponuda` DISABLE KEYS */;
INSERT INTO `ponuda` (`Id`, `SmjestajId`, `DestinacijaId`, `PrevozId`, `Naziv`, `DatumKreiranja`, `Pocetak`, `Kraj`, `Cijena`) VALUES (1,1,2,3,'Nova godina u Parizu','2019-10-08','2019-12-25','2020-01-05',1350.00),(2,2,1,2,'Advent u Beču','2019-10-08','2019-12-20','2019-12-24',430.00);
/*!40000 ALTER TABLE `ponuda` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `prevoz`
--
-- ORDER BY:  `Id`

LOCK TABLES `prevoz` WRITE;
/*!40000 ALTER TABLE `prevoz` DISABLE KEYS */;
INSERT INTO `prevoz` (`Id`, `KompanijaId`, `TipPrevozaId`, `Opis`) VALUES (1,1,1,'Visokoturistički autobusi'),(2,2,1,'Autobus na sprat'),(3,5,2,'Airbus A-320');
/*!40000 ALTER TABLE `prevoz` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Dumping data for table `rezervacija`
--
-- ORDER BY:  `Id`

LOCK TABLES `rezervacija` WRITE;
/*!40000 ALTER TABLE `rezervacija` DISABLE KEYS */;
INSERT INTO `rezervacija` (`Id`, `PonudaId`, `BrojOsoba`) VALUES (1,1,2);
/*!40000 ALTER TABLE `rezervacija` ENABLE KEYS */;
UNLOCK TABLES;

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
-- Dumping data for table `smjestaj`
--
-- ORDER BY:  `Id`

LOCK TABLES `smjestaj` WRITE;
/*!40000 ALTER TABLE `smjestaj` DISABLE KEYS */;
INSERT INTO `smjestaj` (`Id`, `DestinacijaId`, `Naziv`, `Opis`, `Adresa`) VALUES (1,2,'Four Seasons Hotel George V','Zapanjujući hotel u nekadašnjem znamenitom ho','31 Avenue George V'),(2,1,'Sofie Apartments','Apartmani Sofie se nalaze na 5 minuta vožnje ','Kegelgasse 20');
/*!40000 ALTER TABLE `smjestaj` ENABLE KEYS */;
UNLOCK TABLES;

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

-- Dump completed on 2019-10-10 14:17:50
