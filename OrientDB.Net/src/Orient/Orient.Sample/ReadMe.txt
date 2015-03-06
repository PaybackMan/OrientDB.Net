To create DFI database:
1. From Command Prompt
2. navigate to [OrientDB InstallRoot]\bin
3. run: console.bat
4. enter: import database [path to OrientDB.Sample]\Schema\DFI.gz

To browse data from Web Browser
1. navigate to http://localhost:2480
2. select DFI from Database drop-down
3. enter username: root, password: root
4. on Graph tab, enter: traverse all() from Interface

To run OrientDB.Sample
1. change parameter values in line 18 of Program.cs to use your local OrientDB, and JDK/JRE install paths
2. make sure you are not running another instance of OrientDB command windows
3. F5 like the wind!

To run Tests project
1. Make sure you are not running another instance of OrientDB
2. Change path parameters in AssemblySetup.cs like OrientDB.Sample
3. F5

To run Console project
1. Make sure you are not running another instance of OrientDb
2. Change path parameters in Program.cs like in OrientDb.Sample