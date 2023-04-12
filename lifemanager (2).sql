-- phpMyAdmin SQL Dump
-- version 5.0.2
-- https://www.phpmyadmin.net/
--
-- 主機： 127.0.0.1
-- 產生時間： 2020-06-17 05:28:31
-- 伺服器版本： 10.4.11-MariaDB
-- PHP 版本： 7.4.6

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- 資料庫： `lifemanager`
--

-- --------------------------------------------------------

--
-- 資料表結構 `memo`
--

CREATE TABLE `memo` (
  `memoid` int(11) NOT NULL,
  `userid` int(8) NOT NULL,
  `memotitle` text NOT NULL,
  `memo` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 傾印資料表的資料 `memo`
--

INSERT INTO `memo` (`memoid`, `userid`, `memotitle`, `memo`) VALUES
(1, 10000002, '1', '1'),
(2, 10000002, '2', '22'),
(25, 10000002, '5', '3424214'),
(26, 10000002, '3', '543252353'),
(30, 10000002, '3', '哈囉'),
(31, 10000006, '你好', '今天天氣很好'),
(32, 10000006, '我不好', '你怎麼了呀'),
(33, 10000006, '原因', '他今天欺負我'),
(34, 10000006, '還有嗎', '還說要打我'),
(35, 10000006, '願望', '希望他明天不要來'),
(37, 10000002, '你好', 'hjggkhg'),
(39, 10000002, '345', 'guhiu'),
(43, 10000005, '1234', ''),
(46, 10000005, '123', ''),
(48, 10000006, '123', ''),
(49, 10000006, '1234', ''),
(50, 10000006, '4324', ''),
(51, 10000006, '3764', 'fsgdsgdf'),
(53, 0, '考試範圍', 'CH6~CH9'),
(54, 0, '期末報告', '6/20要報告VB'),
(55, 0, '媽媽生日', '禮拜五前要買禮物'),
(56, 0, '車票', '6/20線上訂票'),
(58, 0, '我生日', '6/20');

-- --------------------------------------------------------

--
-- 資料表結構 `mything`
--

CREATE TABLE `mything` (
  `userid` int(8) NOT NULL,
  `thingid` int(11) NOT NULL,
  `tname` text NOT NULL,
  `amount` int(11) NOT NULL,
  `price` int(11) NOT NULL,
  `kind` text NOT NULL,
  `place` text NOT NULL,
  `buyingdate` date NOT NULL,
  `endingdate` date NOT NULL,
  `note` text NOT NULL,
  `state` varchar(3) NOT NULL,
  `shareid` varchar(1000) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 傾印資料表的資料 `mything`
--

INSERT INTO `mything` (`userid`, `thingid`, `tname`, `amount`, `price`, `kind`, `place`, `buyingdate`, `endingdate`, `note`, `state`, `shareid`) VALUES
(10000002, 43, 'su3', 0, 0, '', '', '2020-06-10', '2020-06-15', 'ghkhg', '共享', ''),
(10000002, 46, '12233', 0, 0, '', '', '2020-06-15', '2020-06-15', '', '私有', ''),
(10000002, 49, '123', 1, 3, '', '', '2018-07-01', '2020-05-25', '77678679', '私有', ''),
(10000002, 50, '5432', 543, 543, '', '', '2020-06-15', '2020-06-15', '35425433334435', '共享', ''),
(10000002, 51, '435', 543, 543, '電器', '鞋櫃', '2020-06-15', '2020-06-15', '453543', '共享', '10000005 ,10000007'),
(10000002, 52, '', 0, 0, '', '', '2020-06-16', '2020-06-16', '', '共享', ''),
(10000002, 53, '', 0, 0, '', '', '2020-06-16', '2020-06-16', '', '共享', ''),
(10000018, 61, '蛋', 1, 47, '食物', '冰箱', '2020-06-10', '2020-06-24', '一盒6顆', '私有', ''),
(10000018, 62, '水', 1, 20, '食物', '冰箱', '2020-06-17', '2020-06-17', '', '私有', ''),
(10000018, 63, '衛生紙', 6, 174, '日用品', '儲藏室', '2020-06-10', '2020-06-24', '', '共享', '10000005 10000007 '),
(10000018, 69, '汽水', 6, 78, '食物', '冰箱', '2020-06-17', '2020-06-17', '', '共享', ',10000021');

-- --------------------------------------------------------

--
-- 資料表結構 `sharedid`
--

CREATE TABLE `sharedid` (
  `userid` int(8) NOT NULL,
  `thingid` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- --------------------------------------------------------

--
-- 資料表結構 `shoppinglist`
--

CREATE TABLE `shoppinglist` (
  `tid` int(11) NOT NULL,
  `userid` int(8) NOT NULL,
  `name` varchar(11) NOT NULL,
  `amount` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 傾印資料表的資料 `shoppinglist`
--

INSERT INTO `shoppinglist` (`tid`, `userid`, `name`, `amount`) VALUES
(13, 10000002, 'hello', 1),
(14, 10000002, 'hello', 3),
(25, 10000002, '123', 321),
(29, 10000005, '1', 1),
(30, 10000005, '2', 2),
(31, 10000005, '3', 3),
(32, 10000005, '4', 4),
(33, 10000005, '5', 5),
(35, 10000005, '6', 6),
(36, 10000005, '7', 7),
(37, 10000005, '8', 0),
(38, 10000005, '123', 2),
(40, 0, '紅筆', 3),
(41, 0, '橡皮擦', 2),
(42, 0, '西瓜', 1),
(43, 0, '芒果', 5),
(44, 0, '高麗菜', 1),
(45, 0, '洗髮精', 2),
(48, 0, '藍筆', 1);

-- --------------------------------------------------------

--
-- 資料表結構 `user`
--

CREATE TABLE `user` (
  `userid` int(8) NOT NULL,
  `email` text NOT NULL,
  `name` text NOT NULL,
  `password` text NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- 傾印資料表的資料 `user`
--

INSERT INTO `user` (`userid`, `email`, `name`, `password`) VALUES
(10000001, 'ann@gmail.com', 'ann', 'ann'),
(10000002, '123@gmail.com', '美人', '1234'),
(10000005, 'lulu@gmail.com', 'lulu2', 'lulu'),
(10000006, '123@gmail.com', '美人', '1234'),
(10000007, 'yushi@gmail.com', 'yushi', 'yushi'),
(10000008, 'laoliu@gmail.com', 'laoliu', 'laoliu'),
(10000010, 'hi@gmail.com', 'hi', 'hi'),
(10000013, '123@.com', '', ''),
(10000014, 'abc@.com', '123', '123'),
(10000015, 'hello@gmail.com', 'hello', 'hello'),
(10000016, 'bye@gmail.com', 'bye', 'bye'),
(10000017, 'ok@gmil.com', 'ok', 'ok'),
(10000018, 'demo@gmail.com', 'demo', 'demo'),
(10000021, 'test@gmail.com', '阿賢', 'test');

--
-- 已傾印資料表的索引
--

--
-- 資料表索引 `memo`
--
ALTER TABLE `memo`
  ADD PRIMARY KEY (`memoid`);

--
-- 資料表索引 `mything`
--
ALTER TABLE `mything`
  ADD PRIMARY KEY (`thingid`);

--
-- 資料表索引 `sharedid`
--
ALTER TABLE `sharedid`
  ADD KEY `userid` (`userid`);

--
-- 資料表索引 `shoppinglist`
--
ALTER TABLE `shoppinglist`
  ADD PRIMARY KEY (`tid`);

--
-- 資料表索引 `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`userid`);

--
-- 在傾印的資料表使用自動遞增(AUTO_INCREMENT)
--

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `memo`
--
ALTER TABLE `memo`
  MODIFY `memoid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=59;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `mything`
--
ALTER TABLE `mything`
  MODIFY `thingid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=70;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `shoppinglist`
--
ALTER TABLE `shoppinglist`
  MODIFY `tid` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=49;

--
-- 使用資料表自動遞增(AUTO_INCREMENT) `user`
--
ALTER TABLE `user`
  MODIFY `userid` int(8) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10000022;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
