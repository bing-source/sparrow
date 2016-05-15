开发语言：python34, pysnmp

## 1. trap-sender

发送一个自定义的 snmp trap 消息。

Usage:
```shell
trap-sender.py [flag] <x.x.x.x, x.x.x.x...>  #发送目的地 x.x.x.x, x.x.x.x...
Flag:
        -h --help: print help message
        -f --pdufile: trap PDU structure file #是一个 json 文件，用来定义 trap 消息的结构。
        -a --agent: trap PDU's agent #trap PDU 的 Agent
```

A simple config file:
```json
{
    "enterprise": "1.3.6.1.4.1.8072.4",
    "generictrap": 6,
    "specifictrap": 0,
    "variables": [{
        "oid": ".1.3.6.1.2.1.1.5.0",
        "type": "OctetString",
        "value": "sysName"
    }]
}
```
*目前 variables 的类型只支持: OctetString, Integer*

## 2. trap-receiver

运行后默认监听 `0.0.0.0:udp/162`，收到 trap 消息后，将消息格式化，然后存储到数据库中。

从 webHost.db 中读取设备信息。

注意：XP系统不支持端口检查。

Usage:
```shell
trap-receiver.py [flag]
Flag:
        -h --help: print help message
        -b --bind: listening address and port (0.0.0.0:162)
        -f --dbfile: sqlite3 database file
        --dbfile1: fetch hostname from the database (../webHost.db)
        --printf-dir: trap message format configuration file directory
```

A simple config file:
```js
[{
    "generictrap": 0,
    "printf": "Port {sp} LinkDown",
    "alarmLevel":0
},{
    "generictrap": 6,
    "enterprise": "1.3.6.1.4.1.8072.4",
    "specifictrap": 3,
    "printf": "slot {0} system startup",
    "variables": [
        "1.3.6.1.2.1.1.5.0"
    ],
    "alarmLevel": 0
}]
```
接收到一个 trap message 后, 首先匹配 generictrap, 如果是 0-5, 则直接输出 printf. 如果 generictrap 等于 6, 就匹配 enterprise 和 specifictrap, 然后输出 printf.

printf 字符串中的参数 `{sp}` 会被替换成 specifictrap 的值, 数字形式的参数 `{x}` 会被替换成 `variables[x]` 的值.

alarmLevel 是告警级别：0代表信息，1代表警告，2代表严重。

## 3. poller

从 webHost.db 中读取设备信息，然后用 ICMP 测试主机在状态，对于不在线的主机，调用trapSender向中心网管报告，并向 stdout 输出。

Usage:
```shell
poller.py [flag] x.x.x.x x.x.x.x...
Flag:
        -h --help: print help message
        -f --pdufile: Trap PDU structure file (trap-pdu.json)
        -t --timeout: Poller waiting for response time(seconds).
        -r --retry: Poller test times.
        --dbfile1: fetch ipaddr from the database (../webHost.db)
```

参数的使用请参考trapSender。

## 4. 打包成 exe 文件

当前目录下运行 `python ./setup.py py2exe`，会自动生成一个 dist 目录，可执行文件就在这个目录下。
