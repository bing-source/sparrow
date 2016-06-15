/*
Navicat MySQL Data Transfer

Source Server         : localhost_3306
Source Server Version : 50712
Source Host           : localhost:3306
Source Database       : fmc_webhost

Target Server Type    : MYSQL
Target Server Version : 50712
File Encoding         : 65001

Date: 2016-05-15 15:46:41
*/

SET FOREIGN_KEY_CHECKS=0;

-- ----------------------------
-- Table structure for accounts
-- ----------------------------
DROP TABLE IF EXISTS `accounts`;
CREATE TABLE `accounts` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `username` varchar(32) NOT NULL,
  `password` varchar(32) NOT NULL,
  `create_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `username` (`username`)
) ENGINE=MyISAM AUTO_INCREMENT=0 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for hostgroup
-- ----------------------------
DROP TABLE IF EXISTS `hostgroup`;
CREATE TABLE `hostgroup` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `groupName` varchar(50) NOT NULL,
  `sort` tinyint(4) unsigned DEFAULT '0',
  PRIMARY KEY (`id`),
  UNIQUE KEY `groupName` (`groupName`)
) ENGINE=MyISAM AUTO_INCREMENT=0 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for polling_logs
-- ----------------------------
DROP TABLE IF EXISTS `polling_logs`;
CREATE TABLE `polling_logs` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `hostid` int(10) unsigned NOT NULL,
  `logtxt` varchar(255) DEFAULT '',
  `ischk` tinyint(1) unsigned DEFAULT '0',
  `create_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  KEY `idx_host_log_ischk` (`ischk`)
) ENGINE=InnoDB AUTO_INCREMENT=0 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for trap_messages
-- ----------------------------
DROP TABLE IF EXISTS `trap_messages`;
CREATE TABLE `trap_messages` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `ipaddr` varchar(15) DEFAULT '',
  `hostgroup` int(10) unsigned DEFAULT '0',
  `hostname` varchar(50) DEFAULT '',
  `level` tinyint(4) DEFAULT '0',
  `message` varchar(1000) DEFAULT '',
  `create_at` datetime DEFAULT CURRENT_TIMESTAMP,
  `confirmed` tinyint(1) DEFAULT '0',
  PRIMARY KEY (`id`),
  KEY `idx_trap_messages_ipaddr` (`ipaddr`),
  KEY `idx_trap_messages_level` (`level`),
  KEY `idx_trap_messages_confirmed` (`confirmed`)
) ENGINE=InnoDB AUTO_INCREMENT=0 DEFAULT CHARSET=utf8;

-- ----------------------------
-- Table structure for webhost
-- ----------------------------
DROP TABLE IF EXISTS `webhost`;
CREATE TABLE `webhost` (
  `id` int(10) unsigned NOT NULL AUTO_INCREMENT,
  `HostName` varchar(50) DEFAULT '',
  `HostGroup` int(10) unsigned DEFAULT '0',
  `IPAddr` varchar(15) NOT NULL,
  `Port` varchar(5) DEFAULT '80',
  `UserName` varchar(50) DEFAULT '',
  `Password` varchar(50) DEFAULT '',
  `Auth` tinyint(1) unsigned DEFAULT '0',
  `Url` varchar(255) DEFAULT '/',
  `GetPara` varchar(255) DEFAULT '',
  `PostPara` varchar(255) DEFAULT '',
  `isicmp` tinyint(1) unsigned DEFAULT '1',
  `create_at` datetime DEFAULT CURRENT_TIMESTAMP,
  PRIMARY KEY (`id`),
  UNIQUE KEY `IPAddr` (`IPAddr`),
  KEY `idx_webhost_isicmp` (`isicmp`),
  KEY `idx_webhost_HostName` (`HostName`),
  KEY `idx_webhost_HostGroup` (`HostGroup`)
) ENGINE=MyISAM AUTO_INCREMENT=0 DEFAULT CHARSET=utf8;
