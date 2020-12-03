-- phpMyAdmin SQL Dump
-- version 4.9.5
-- https://www.phpmyadmin.net/
--
-- Host: localhost:3307
-- Generation Time: Nov 01, 2020 at 05:01 PM
-- Server version: 5.7.24
-- PHP Version: 7.4.1

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `schooldb`
--

-- --------------------------------------------------------

--
-- Table structure for table `classes`
--

CREATE TABLE `classes` (
  `classid` int(20) NOT NULL,
  `classcode` varchar(255) DEFAULT NULL,
  `teacherid` bigint(20) DEFAULT NULL,
  `startdate` date DEFAULT NULL,
  `finishdate` date DEFAULT NULL,
  `classname` varchar(255) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `classes`
--

INSERT INTO `classes` (`classid`, `classcode`, `teacherid`, `startdate`, `finishdate`, `classname`) VALUES
(1, 'http5101', 1, '2018-09-04', '2018-12-14', 'Web Application Development'),
(2, 'http5102', 2, '2018-09-04', '2018-12-14', 'Project Management'),
(3, 'http5103', 5, '2018-09-04', '2018-12-14', 'Web Programming'),
(4, 'http5104', 7, '2018-09-04', '2018-12-14', 'Digital Design'),
(5, 'http5105', 8, '2018-09-04', '2018-12-14', 'Database Development'),
(6, 'http5201', 2, '2019-01-08', '2019-04-27', 'Security & Quality Assurance'),
(7, 'http5202', 3, '2019-01-08', '2019-04-27', 'Web Application Development 2'),
(8, 'http5203', 4, '2019-01-08', '2019-04-27', 'XML and Web Services'),
(9, 'http5204', 5, '2019-01-08', '2019-04-27', 'Mobile Development'),
(10, 'http5205', 6, '2019-01-08', '2019-04-27', 'Career Connections'),
(11, 'http5206', 8, '2019-01-08', '2019-04-27', 'Web Information Architecture'),
(12, 'PHYS2203', 10, '2019-09-04', '2019-12-14', 'Massage Therapy');

-- --------------------------------------------------------

--
-- Table structure for table `students`
--

CREATE TABLE `students` (
  `studentid` int(20) UNSIGNED NOT NULL,
  `studentfname` varchar(255) NOT NULL,
  `studentlname` varchar(255) NOT NULL,
  `studentnumber` varchar(255) NOT NULL,
  `enroldate` date DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `students`
--

INSERT INTO `students` (`studentid`, `studentfname`, `studentlname`, `studentnumber`, `enroldate`) VALUES
(1, 'Sarah', 'Valdez', 'N1678', '2018-06-18'),
(2, 'Jennifer', 'Faulkner', 'N1679', '2018-08-02'),
(3, 'Austin', 'Simon', 'N1682', '2018-06-14'),
(4, 'Mario', 'English', 'N1686', '2018-07-03'),
(5, 'Elizabeth', 'Murray', 'N1690', '2018-07-12'),
(6, 'Kevin', 'Williams', 'N1691', '2018-08-04'),
(7, 'Jason', 'Freeman', 'N1694', '2018-08-16'),
(8, 'Nicole', 'Armstrong', 'N1698', '2018-07-10'),
(9, 'Colleen', 'Riley', 'N1702', '2018-07-15'),
(10, 'Julie', 'Salazar', 'N1705', '2018-07-10'),
(11, 'Dr.', 'Bridges', 'N1709', '2018-08-22'),
(12, 'Vanessa', 'Cox', 'N1712', '2018-08-17'),
(13, 'Denise', 'Jackson', 'N1714', '2018-07-26'),
(14, 'Roy', 'Davidson', 'N1715', '2018-08-11'),
(15, 'Ryan', 'Walters', 'N1717', '2018-07-25'),
(16, 'Patricia', 'Sweeney', 'N1719', '2018-08-08'),
(18, 'Melissa', 'Morales', 'N1723', '2018-08-10'),
(19, 'Kimberly', 'Johnson', 'N1727', '2018-08-02'),
(20, 'Andrea', 'Flores', 'N1731', '2018-07-09'),
(21, 'Jason', 'II', 'N1732', '2018-06-05'),
(22, 'David', 'Dunlap', 'N1734', '2018-08-27'),
(23, 'Elizabeth', 'Thompson', 'N1736', '2018-08-07'),
(24, 'Becky', 'Medina', 'N1737', '2018-07-02'),
(25, 'Wayne', 'Collins', 'N1740', '2018-07-20'),
(26, 'Nicole', 'Henderson', 'N1742', '2018-06-07'),
(27, 'David', 'Larson', 'N1744', '2018-07-19'),
(28, 'John', 'Reed', 'N1748', '2018-08-15'),
(29, 'Richard', 'King', 'N1751', '2018-08-17'),
(30, 'Alexander', 'Bennett', 'N1752', '2018-07-29'),
(31, 'Caitlin', 'Cummings', 'N1756', '2018-08-02'),
(32, 'Christine', 'Bittle', 'N0001', '2020-10-05');

-- --------------------------------------------------------

--
-- Table structure for table `studentsxclasses`
--

CREATE TABLE `studentsxclasses` (
  `studentxclassid` int(20) NOT NULL,
  `studentid` bigint(20) DEFAULT NULL,
  `classid` bigint(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `studentsxclasses`
--

INSERT INTO `studentsxclasses` (`studentxclassid`, `studentid`, `classid`) VALUES
(1, 1, 1),
(2, 1, 2),
(3, 1, 3),
(4, 1, 4),
(5, 1, 7),
(6, 3, 1),
(7, 3, 2),
(8, 3, 3),
(9, 3, 4),
(10, 3, 7),
(11, 4, 1),
(12, 4, 2),
(13, 4, 3),
(14, 4, 4),
(15, 4, 7),
(16, 5, 1),
(17, 5, 2),
(18, 5, 3),
(19, 5, 4),
(20, 5, 7),
(21, 6, 1),
(22, 6, 2),
(23, 6, 3),
(24, 6, 4),
(25, 6, 7),
(26, 7, 1),
(27, 7, 2),
(28, 7, 3),
(29, 7, 4),
(30, 7, 7),
(31, 8, 1),
(32, 8, 2),
(33, 8, 3),
(34, 8, 4),
(35, 9, 1),
(36, 9, 2),
(37, 9, 3),
(38, 9, 4),
(39, 9, 7),
(40, 10, 1),
(41, 10, 2),
(42, 10, 3),
(43, 10, 4),
(44, 10, 7),
(45, 11, 1),
(46, 11, 2),
(47, 11, 3),
(48, 11, 4),
(49, 11, 7),
(50, 12, 1),
(51, 12, 2),
(52, 12, 3),
(53, 12, 4),
(54, 12, 7),
(55, 14, 1),
(56, 14, 2),
(57, 14, 3),
(58, 14, 4),
(59, 14, 7),
(60, 15, 1),
(61, 15, 2),
(62, 15, 3),
(63, 15, 4),
(64, 15, 7),
(65, 16, 1),
(66, 16, 2),
(67, 16, 3),
(68, 16, 4),
(69, 16, 7),
(75, 18, 1),
(76, 18, 2),
(77, 18, 3),
(78, 18, 4),
(79, 18, 7),
(80, 19, 1),
(81, 19, 2),
(82, 19, 3),
(83, 19, 4),
(84, 19, 7),
(85, 20, 1),
(86, 20, 2),
(87, 20, 3),
(88, 20, 4),
(89, 20, 7),
(90, 21, 1),
(91, 21, 2),
(92, 21, 3),
(93, 22, 1),
(94, 22, 2),
(95, 22, 3),
(96, 22, 4),
(97, 22, 7),
(98, 23, 1),
(99, 23, 2),
(100, 23, 3),
(101, 23, 4),
(102, 23, 7),
(103, 25, 1),
(104, 25, 2),
(105, 25, 3),
(106, 25, 4),
(107, 25, 7),
(108, 26, 1),
(109, 26, 2),
(110, 26, 3),
(111, 26, 4),
(112, 26, 7),
(113, 27, 1),
(114, 27, 2),
(115, 27, 3),
(116, 27, 4),
(117, 27, 7),
(118, 28, 1),
(119, 28, 2),
(120, 28, 3),
(121, 28, 4),
(122, 28, 7),
(123, 29, 1),
(124, 29, 2),
(125, 29, 3),
(126, 29, 4),
(127, 29, 7),
(128, 30, 1),
(129, 30, 2),
(130, 30, 3),
(131, 30, 4),
(132, 30, 7),
(133, 31, 1),
(134, 31, 2),
(135, 31, 3),
(136, 31, 4),
(137, 31, 7);

-- --------------------------------------------------------

--
-- Table structure for table `teachers`
--

CREATE TABLE `teachers` (
  `teacherid` int(20) NOT NULL,
  `teacherfname` varchar(255) DEFAULT NULL,
  `teacherlname` varchar(255) DEFAULT NULL,
  `employeenumber` varchar(255) DEFAULT NULL,
  `hiredate` datetime DEFAULT NULL,
  `salary` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `teachers`
--

INSERT INTO `teachers` (`teacherid`, `teacherfname`, `teacherlname`, `employeenumber`, `hiredate`, `salary`) VALUES
(1, 'Alexander', 'Bennett', 'T378', '2016-08-05 00:00:00', '55.30'),
(2, 'Caitlin', 'Cummings', 'T381', '2014-06-10 00:00:00', '62.77'),
(3, 'Linda', 'Chan', 'T382', '2015-08-22 00:00:00', '60.22'),
(4, 'Lauren', 'Smith', 'T385', '2014-06-22 00:00:00', '74.20'),
(5, 'Jessica', 'Morris', 'T389', '2012-06-04 00:00:00', '48.62'),
(6, 'Thomas', 'Hawkins', 'T393', '2016-08-10 00:00:00', '54.45'),
(7, 'Shannon', 'Barton', 'T397', '2013-08-04 00:00:00', '64.70'),
(8, 'Dana', 'Ford', 'T401', '2014-06-26 00:00:00', '71.15'),
(9, 'Cody', 'Holland', 'T403', '2016-06-13 00:00:00', '43.20'),
(10, 'John', 'Taram', 'T505', '2015-10-23 00:00:00', '79.63');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `classes`
--
ALTER TABLE `classes`
  ADD PRIMARY KEY (`classid`);

--
-- Indexes for table `students`
--
ALTER TABLE `students`
  ADD PRIMARY KEY (`studentid`);

--
-- Indexes for table `studentsxclasses`
--
ALTER TABLE `studentsxclasses`
  ADD PRIMARY KEY (`studentxclassid`);

--
-- Indexes for table `teachers`
--
ALTER TABLE `teachers`
  ADD PRIMARY KEY (`teacherid`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `classes`
--
ALTER TABLE `classes`
  MODIFY `classid` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;

--
-- AUTO_INCREMENT for table `students`
--
ALTER TABLE `students`
  MODIFY `studentid` int(20) UNSIGNED NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=33;

--
-- AUTO_INCREMENT for table `studentsxclasses`
--
ALTER TABLE `studentsxclasses`
  MODIFY `studentxclassid` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=138;

--
-- AUTO_INCREMENT for table `teachers`
--
ALTER TABLE `teachers`
  MODIFY `teacherid` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
