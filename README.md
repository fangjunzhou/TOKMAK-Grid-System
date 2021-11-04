# TOKMAK Grid System

TOKMAK Grid System是一个针对Unity引擎开发的网格框架，本项目由鳍片环流室 Fin TOKMAK开发组开发，使用此包请遵守相关许可。

使用此框架可以快速在游戏中部署基于有向图的虚拟网格，为游戏中玩家和敌人的寻路、程序化地图生成、建造系统等打下基础。

# 下载和使用

## 依赖项

在使用本框架之前，您需要安装本项目的依赖包，包括：
`com.dbrizov.naughtyattributes`
`net.wraithavengames.unityinterfacesupport`
`com.fintokmak.priorityqueue`

您可以直接将以下内容复制到项目包文件管理器的`manifest.json`中以快速导入所有依赖项

```
"com.dbrizov.naughtyattributes": "https://github.com/dbrizov/NaughtyAttributes.git#upm",
"com.fintokmak.priorityqueue": "https://github.com/Fangjun-Zhou/Unity-Priority-Queue.git#upm-priorityqueue",
"net.wraithavengames.unityinterfacesupport": "https://github.com/TheDudeFromCI/Unity-Interface-Support.git?path=/Packages/net.wraithavengames.unityinterfacesupport"
```

## 安装

安装TOKMAK Grid System可以在package manager中直接添加`https://github.com/Fangjun-Zhou/Grid-System.git#upm-gridsystem`

或是将以下内容复制到项目包文件管理器的`manifest.json`中

```
"com.fintokmak.gridsystem": "https://github.com/Fangjun-Zhou/Grid-System.git#upm-gridsystem"
```

# 相关库的信息

## Unity Priority-Queue

TOKMAK Grid System使用了Unity Priority-Queue作为依赖包之一

Unity Priority-Queue是由鳍片环流室 Fin TOKMAK开发组开发的在Unity中使用的Priority Queue

Unity Priority-Queue的Git Hub仓库在[这里](https://github.com/Fangjun-Zhou/Unity-Priority-Queue)

Unity Priority-Queue的使用文档在[这里](https://fangjun-zhou.github.io/Unity-Priority-Queue/)

# 文档

TOKMAK Grid System的使用文档请看[这里](https://fangjun-zhou.github.io/TOKMAK-Grid-System/)
