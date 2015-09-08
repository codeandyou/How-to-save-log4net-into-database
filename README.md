# How to save log4net into database

How to save log4net log into database
How to use log4net in .net 
What is Log4net

Log4net is an open source .net library to log output to a variety of sources  like console, SMTP, Plain text, Database etc. Log4net is a port of the popular log4J library used in Java. Log4net developed by Apache Foundation. Full details of log4net can be found at its project homepage. Its powerful tool to logging application output to different targets. Log4net provide different types of provider to save logging into plain text, database etc.  Log4net enable logging at runtime without modifying the application binary. Its provide high speed of logging. 
log4net is the notion of hierarchical loggers log4net is designed for speed and flexibility
 
Home page of log4net- http://logging.apache.org/log4net/index.html

Following is steps to save log4net log into database

##1. Add Log4net.dll into your project
##2. Add log4net into Global.asax.cs
##3. Register log4net in configSections
##4. Use log4net configuration in web.config sections
##5. Create a database and table to save log into Sql server. I am creating "Log4NetTest" database and "AppLog" table to save log into database
##6. Use following Log4net settings in your controller, where you want use log4net

#Step 1 . Add Log4net.dll into your project
 
Add log4net "log4net.dll" library into your project. you can download log4net binary from following URL

https://logging.apache.org/log4net/download_log4net.cgi

Its contains different bin file for different .net version. You can add log4net.dll according to your requirement and .net version.

Or 

Package Manager- You can install log4net via package manager
Go to Tools>>NuGet Package Manager >> Package Manager
then run 

PM> Install-Package log4net

#Step 2. Add log4net into Global.asax.cs

Add following code into Global.asax.cs file on "Application_Start()" event.

```C#
log4net.Config.XmlConfigurator.Configure();
```
 
#Step 3. Register log4net in configSections

Add following code into configSections in web.config

```C#

<section name="log4net" type="log4net.Config.Log4NetConfigurationSectionHandler, log4net" />

```

#Step 4. Use log4net configuration in web.config sections

Add following code below configSections in web.config
 
```c#
<log4net>
    <appender name="RollingLogFileAppender" type="log4net.Appender.RollingFileAppender">
      <file value="C:\\log.txt" />
      <appendToFile value="true" />
      <rollingStyle value="Size" />
      <maxSizeRollBackups value="10" />
      <maximumFileSize value="10MB" />
      <staticLogFileName value="true" />
      <layout type="log4net.Layout.PatternLayout">
        <conversionPattern value="%-5p %d %5rms %-22.22c{1} %-18.18M - %m%n" />
      </layout>
    </appender>
     <appender name="AdoNetAppender" type="log4net.Appender.AdoNetAppender">
      <bufferSize value="1" />
      <connectionType value="System.Data.SqlClient.SqlConnection, System.Data, Version=1.0.3300.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" />
      <connectionString value="data source=[SqlServer];Initial Catalog=[DatabaseName];user id=sa;password=[System12345];" />
      <commandText value="INSERT INTO AppLog ([Date],[Thread],[Level],[Logger],[Message],[Exception]) VALUES (@log_date, @thread, @log_level, @logger, @message,  
@exception)" />
      <parameter>
        <parameterName value="@log_date" />
        <dbType value="DateTime" />
        <layout type="log4net.Layout.RawTimeStampLayout" />
      </parameter>
      <parameter>
        <parameterName value="@thread" />
        <dbType value="String" />
        <size value="255" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%thread" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value="@log_level" />
        <dbType value="String" />
        <size value="50" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%level" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value="@logger" />
        <dbType value="String" />
        <size value="255" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%logger" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value="@message" />
        <dbType value="String" />
        <size value="4000" />
        <layout type="log4net.Layout.PatternLayout">
          <conversionPattern value="%message" />
        </layout>
      </parameter>
      <parameter>
        <parameterName value="@exception" />
        <dbType value="String" />
        <size value="2000" />
        <layout type="log4net.Layout.ExceptionLayout" />
      </parameter>
    </appender>
    <root>
      <level value="ALL" />
      <appender-ref ref="RollingLogFileAppender"  />   
     <appender-ref ref="AdoNetAppender" />             
    </root>
  </log4net> 
  ```

#Step 5. Create a database and table to save log into sql server. I am creating "Log4NetTest" database and "AppLog" table to save log into database
 
 --Sql Script for save log4net log into sql server database

```Sql
Create database Log4NetTest

Use Log4NetTest

CREATE TABLE [dbo].[AppLog](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [varchar](max) NOT NULL,
	[Exception] [varchar](max) NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
 
Select * from AppLog 
```

#Step 6. Use following Log4net settings in your controller, where you want use log4net

```C#

private static log4net.ILog Log { get; set; }

ILog log = log4net.LogManager.GetLogger(typeof(classtype));      //type of class

log.Debug("Debug message");
log.Warn("Warn message");
log.Error("Error message");
log.Fatal("Fatal message");

```

Thanks
www.codeandyou.com

http://www.codeandyou.com/2015/09/how-to-save-log4net-log-into-database.html

Keywords -  How to save log4net log into database , How to use log4net in .net  , 
What is Log4net


