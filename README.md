## alt:V BlipSystem
A C# blip system for alt:V using MySQL & PostgreSQL.\
You can decide if u want to use MySQL or PostgreSQL.\
\
WARNING: This is not a standalone resource!

# How to use
This repository includes the source code of a simple blip system.\
\
Just add the project as dependecy to yours and create a BlipService object.\
If you did create one you just have to call its function SynchronizeBlips().\
Integrate its call at points every player has to pass otherwise not all players will receive the blips.\
\
In addition to this, place the blips.js file in your client folder and add it to your bundler.\
\
To use a Postgres database execute the postgres.sql file (Query).\
To use a MySql database execute the mysql.sql file (Query).\
Insert your blips into the table.\
\
Before you can launch your server the DatabaseConfig.json has to be placed nearby the altv-server file.\
Besides, you have to configure the DatabaseConfig.json, possible Types are postgres and mysql.\
\
Done.