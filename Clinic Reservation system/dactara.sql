-- phpMyAdmin SQL Dump
-- version 5.1.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Apr 28, 2022 at 04:57 PM
-- Server version: 10.4.22-MariaDB
-- PHP Version: 8.1.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `dactara`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `Admin_ID` int(11) NOT NULL,
  `Admin_Username` varchar(20) NOT NULL,
  `Admin_Email` varchar(20) NOT NULL,
  `Admin_PhoneNumber` int(11) NOT NULL,
  `Admin_Password` varchar(8) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`Admin_ID`, `Admin_Username`, `Admin_Email`, `Admin_PhoneNumber`, `Admin_Password`) VALUES
(1, 'Alaa', 'Alaa1@gmail.com', 1003457884, '1234'),
(2, 'Mayar2', 'Mayar2@gmail.com', 1245879652, '1234'),
(3, 'Salma3', 'Salma3@gmail.com', 1268974532, '1234'),
(4, 'Ahmed4', 'Ahmed4@gmail.com', 1111789955, '1234'),
(5, 'Dactara', 'Dactara1@gmail.com', 19558, '1234');

-- --------------------------------------------------------

--
-- Table structure for table `clinic`
--

CREATE TABLE `clinic` (
  `Clinic_ID` int(11) NOT NULL,
  `Clinic_Name` varchar(10) NOT NULL,
  `Street_Name` varchar(10) NOT NULL,
  `Street_Number` varchar(10) NOT NULL,
  `Reservation_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `clinic`
--

INSERT INTO `clinic` (`Clinic_ID`, `Clinic_Name`, `Street_Name`, `Street_Number`, `Reservation_ID`) VALUES
(12, 'The Dentis', 'Madinaty', '12', 1),
(13, 'Denta Care', 'Jezirah', '5', 6),
(14, 'CareClinic', 'Newcairo', '9', 2),
(15, 'TwinClinic', 'TwinTowers', '6', 7),
(16, 'SalehClinc', 'Madinaty', '7', 3),
(17, 'KidsCare', 'ElSherouk', '10', 3),
(18, 'Nour', 'Marghany', '15', 8),
(19, 'Blink', 'Elthawra', '8', 4),
(20, 'BoneClinic', 'Nourth90', '9', 5),
(21, 'TheB', 'Thawra', '15', 9);

-- --------------------------------------------------------

--
-- Table structure for table `doctor`
--

CREATE TABLE `doctor` (
  `Doctor_ID` int(11) NOT NULL,
  `Doctor_Name` varchar(10) NOT NULL,
  `Doctor_Specialization` varchar(10) NOT NULL,
  `Doctor_PhoneNumber` int(11) NOT NULL,
  `Doctor_Email` varchar(20) NOT NULL,
  `Detection_Price` int(11) NOT NULL,
  `Doctor_ClinicName` varchar(10) NOT NULL,
  `Clinic_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `doctor`
--

INSERT INTO `doctor` (`Doctor_ID`, `Doctor_Name`, `Doctor_Specialization`, `Doctor_PhoneNumber`, `Doctor_Email`, `Detection_Price`, `Doctor_ClinicName`, `Clinic_ID`) VALUES
(1, 'OmarAmer', 'Dentist', 1247596821, 'Omaramer@gmail.com', 250, 'The Dentis', 12),
(2, 'TarekHosny', 'Dentist', 1032365887, 'Tarek.Hosny@gmail.co', 200, 'DentaCare', 13),
(3, 'HeshamMans', 'Otorhinola', 1255587964, 'HeshamMansour@gmail.', 400, 'CareClinic', 14),
(4, 'AhmedAbdel', 'Otorhinola', 126755598, 'Ahmed.Abdelkhaliek@g', 300, 'TwinClinic', 15),
(5, 'AhmedMamdo', 'Pediatrici', 1226445521, 'AhmedMamdouh@gmail.c', 150, 'SalehClini', 16),
(6, 'Hassan Tar', 'Pediatrici', 1000005448, 'HassanTarek@gmail.co', 150, 'Kids Care', 17),
(7, 'TarekAbdel', 'Ophthalmol', 1157846952, 'Tarek.AH@gmail.com', 300, 'Nour', 18),
(8, 'TamerElreg', 'Ophthalmol', 1111235578, 'TamerElRegal@gmail.c', 400, 'Blink', 19),
(9, 'Hamdy Same', 'Orthopedis', 1544468720, 'Hamdey.S@gmail.com', 300, 'Bone Clini', 20),
(10, 'Ahmed Alam', 'Orthopedis', 1115541236, 'Ahmed Alam@gmail.com', 300, 'The B', 21);

-- --------------------------------------------------------

--
-- Table structure for table `guest`
--

CREATE TABLE `guest` (
  `Guest_ID` int(11) NOT NULL,
  `Guest_Username` varchar(20) NOT NULL,
  `Guest_Password` varchar(8) NOT NULL,
  `Guest_Email` varchar(10) NOT NULL,
  `Guest_PhoneNumber` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `guest`
--

INSERT INTO `guest` (`Guest_ID`, `Guest_Username`, `Guest_Password`, `Guest_Email`, `Guest_PhoneNumber`) VALUES
(20, 'Omar', '2222', 'Omar.A@gma', 1233658794),
(21, 'Hana', '5555', 'Hana@gmail', 1115578469),
(22, 'Jamila', '4444', 'Jamila@gma', 1544789652),
(23, 'Ann', '7777', 'Ann@gmail.', 1114478956),
(24, 'Hamza', '8888', 'Hamza@gmai', 1225879641),
(25, 'Mohamed', '9999', 'Mohamed@gm', 1000025778),
(26, 'Mariam', '4448', 'Mariam@gma', 1114487536),
(27, 'Sara', '1111', 'Sara@gmail', 1111885674),
(28, 'Mahmoud', '7788', 'Mahmoud@gm', 1255537896),
(29, 'Arwa', '5566', 'Arwa@gmail', 1277785690),
(30, 'Laila', '2233', 'Laila@gmai', 1222235887);

-- --------------------------------------------------------

--
-- Table structure for table `guest_reservation`
--

CREATE TABLE `guest_reservation` (
  `Reservation_Num` int(11) NOT NULL,
  `Guest_Num` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `guest_reservation`
--

INSERT INTO `guest_reservation` (`Reservation_Num`, `Guest_Num`) VALUES
(1, 23),
(6, 29),
(10, 24),
(4, 21),
(8, 22),
(5, 30),
(9, 28),
(2, 26),
(7, 20),
(3, 27);

-- --------------------------------------------------------

--
-- Table structure for table `offer`
--

CREATE TABLE `offer` (
  `Offer_ID` int(11) NOT NULL,
  `Offer_Code` varchar(8) NOT NULL,
  `Offer_Specialization` varchar(20) NOT NULL,
  `Offer_Percentage` varchar(10) NOT NULL,
  `Expiration_Date` date NOT NULL,
  `Clinic_ID` int(11) NOT NULL,
  `Admin_ID` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `offer`
--

INSERT INTO `offer` (`Offer_ID`, `Offer_Code`, `Offer_Specialization`, `Offer_Percentage`, `Expiration_Date`, `Clinic_ID`, `Admin_ID`) VALUES
(1, '1222', 'Dentist', '15%', '2022-06-01', 12, 1),
(2, '9999', 'Dentist', '10%', '2022-05-10', 13, 2),
(3, '7755', 'Otorhinolaryngologis', '20%', '2022-08-01', 14, 3),
(4, '5588', 'Otorhinolaryngologis', '10%', '2022-06-10', 15, 4),
(5, '7777', 'pediatrician', '25%', '2022-07-01', 16, 1),
(6, '4444', 'pediatrician', '10%', '2022-07-15', 17, 2),
(7, '8888', 'Ophthalmologist', '20%', '2022-05-25', 18, 3),
(8, '5555', 'Ophthalmologist', '10%', '2022-09-01', 19, 4),
(9, '1111', 'Orthopedist', '20%', '2022-04-30', 20, 1),
(10, '7778', 'Orthopedist', '20%', '2022-07-30', 21, 2);

-- --------------------------------------------------------

--
-- Table structure for table `reservation`
--

CREATE TABLE `reservation` (
  `Reservation_ID` int(11) NOT NULL,
  `Reservation_Type` varchar(20) NOT NULL,
  `Reservation_Time` time NOT NULL,
  `Reservation_Date` date NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `reservation`
--

INSERT INTO `reservation` (`Reservation_ID`, `Reservation_Type`, `Reservation_Time`, `Reservation_Date`) VALUES
(1, 'Dentist', '10:30:00', '2022-04-06'),
(2, 'Otorhinolaryngologis', '15:00:00', '2022-04-14'),
(3, 'pediatrician', '09:00:00', '2022-04-10'),
(4, 'Ophthalmologist', '14:00:00', '2022-04-16'),
(5, 'Orthopedist', '19:00:00', '2022-04-30'),
(6, 'Dentist', '09:20:00', '2022-04-26'),
(7, 'Otorhinolaryngologis', '16:30:00', '2022-04-10'),
(8, 'Ophthalmologist', '20:15:00', '2022-04-19'),
(9, 'Orthopedist', '10:15:00', '2022-04-13'),
(10, 'Dentist', '14:18:00', '2022-04-27');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`Admin_ID`);

--
-- Indexes for table `clinic`
--
ALTER TABLE `clinic`
  ADD PRIMARY KEY (`Clinic_ID`),
  ADD KEY `reservationClinic_fk` (`Reservation_ID`);

--
-- Indexes for table `doctor`
--
ALTER TABLE `doctor`
  ADD PRIMARY KEY (`Doctor_ID`),
  ADD KEY `clinicDOC_fk` (`Clinic_ID`);

--
-- Indexes for table `guest`
--
ALTER TABLE `guest`
  ADD PRIMARY KEY (`Guest_ID`);

--
-- Indexes for table `guest_reservation`
--
ALTER TABLE `guest_reservation`
  ADD KEY `jointguest_fk` (`Guest_Num`),
  ADD KEY `jointreservation_fk` (`Reservation_Num`);

--
-- Indexes for table `offer`
--
ALTER TABLE `offer`
  ADD PRIMARY KEY (`Offer_ID`),
  ADD KEY `clinic_fk` (`Clinic_ID`),
  ADD KEY `admin_fk` (`Admin_ID`);

--
-- Indexes for table `reservation`
--
ALTER TABLE `reservation`
  ADD PRIMARY KEY (`Reservation_ID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `clinic`
--
ALTER TABLE `clinic`
  ADD CONSTRAINT `reservationClinic_fk` FOREIGN KEY (`Reservation_ID`) REFERENCES `reservation` (`Reservation_ID`);

--
-- Constraints for table `doctor`
--
ALTER TABLE `doctor`
  ADD CONSTRAINT `clinicDOC_fk` FOREIGN KEY (`Clinic_ID`) REFERENCES `clinic` (`Clinic_ID`);

--
-- Constraints for table `guest_reservation`
--
ALTER TABLE `guest_reservation`
  ADD CONSTRAINT `jointguest_fk` FOREIGN KEY (`Guest_Num`) REFERENCES `guest` (`Guest_ID`),
  ADD CONSTRAINT `jointreservation_fk` FOREIGN KEY (`Reservation_Num`) REFERENCES `reservation` (`Reservation_ID`);

--
-- Constraints for table `offer`
--
ALTER TABLE `offer`
  ADD CONSTRAINT `admin_fk` FOREIGN KEY (`Admin_ID`) REFERENCES `admin` (`Admin_ID`),
  ADD CONSTRAINT `clinic_fk` FOREIGN KEY (`Clinic_ID`) REFERENCES `clinic` (`Clinic_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
