# TiledAbs2RelPath
把tiled的tmx里的绝对路径调整为相对路径，但是有要求就是了，不是通用的

因为 Tiled 编辑器保存的是绝对路径，请大家把此目录设定为 D:\WXMaps
即： checkout http://svn/M04/trunk/Arts/武侠/Maps
至 D:\WXMaps

----------------------------------------------------
美术注意：
1. 必须在 D:\WXMaps 下制作地图。
2. tmx 可以保存在 D:\WXMaps 下的任何一个文件夹内，Textures 除外
3. 只能从 Textures 里面拖图集进入编辑器。Textures 里面可以新建文件夹
4. Textures 里可能要规划一下，例如分为2种文件夹，一种文件夹是每个地图单独使用的；另一种是共用的


----------------------------------------------------
备注：
美术按照上面的步骤制作的地图 tmx 内保存的都是图片的绝对路径；
如果此目录不是 D:\WXMaps，打开地图会出错；但可以把 tmx 拖到 TiledAbs2RelPath.exe 上面执行一下，会生成另一个 tmx，这个 tmx 就可以打开了
TiledAbs2RelPath.exe 源代码地址：https://github.com/qcwgithub/TiledAbs2RelPath.git
