-- Check if the database 'nextstop_db' exists
IF EXISTS (SELECT name FROM sys.databases WHERE name = N'nextstop_db')
BEGIN
	PRINT 'Database nextstop_db already exists';
END
ELSE
BEGIN
	EXEC('CREATE DATABASE [nextstop_db]');
	PRINT 'Database nextstop_db created';
	
    /* user */
	EXEC('
		USE [nextstop_db];
		CREATE TABLE [dbo].[user](
			[id] [int] IDENTITY(1,1) NOT NULL,
			[user_name] [varchar](20) NOT NULL,
			[password] [varchar](50) NOT NULL,
			[user_type] [varchar](5) NOT NULL,
				CONSTRAINT [PK_user] PRIMARY KEY CLUSTERED ([id]))
	');
	PRINT 'Table user created';

    /* type_of_day */
    EXEC('
		USE [nextstop_db];
		CREATE TABLE [dbo].[type_of_day](
			[id] [int] IDENTITY(1,1) NOT NULL,
			[name] [varchar](10) NOT NULL,
			[is_special] [bit],
				CONSTRAINT [PK_type_of_day] PRIMARY KEY CLUSTERED ([id]))
	');
	PRINT 'Table type_of_day created';

    /* holiday */
    EXEC('
		USE [nextstop_db];
		CREATE TABLE [dbo].[holiday](
			[id] [int] IDENTITY(1,1) NOT NULL,
			[name] [varchar](30) NOT NULL,
			[start] [date] NOT NULL,
			[end] [date] NOT NULL,
			[type_id] [int] NOT NULL,
				CONSTRAINT [PK_holiday] PRIMARY KEY CLUSTERED ([id]),
                CONSTRAINT [FK_type] FOREIGN KEY (type_id) REFERENCES type_of_day(id))
	');
	PRINT 'Table holiday created';

    /* route */
	EXEC('
		USE [nextstop_db];
		CREATE TABLE [dbo].[route](
			[id] [int] IDENTITY(1,1) NOT NULL,
			[valid_from] [date] NOT NULL,
			[valid_until] [date],
				CONSTRAINT [PK_route] PRIMARY KEY CLUSTERED ([id]))
	');
	PRINT 'Table route created';

    /* planned_route */
	EXEC('
		USE [nextstop_db];
		CREATE TABLE [dbo].[planned_route](
			[id] [int] IDENTITY(1,1) NOT NULL,
			[route_id] [int] NOT NULL,
			[start_time] [time] NOT NULL,
			[type_id] [int] NOT NULL,
				CONSTRAINT [PK_planned_route] PRIMARY KEY CLUSTERED ([id]),
				CONSTRAINT [FK_route] FOREIGN KEY (route_id) REFERENCES route(id),
				CONSTRAINT [FK_type_of_day] FOREIGN KEY (type_id) REFERENCES type_of_day(id))
	');
	PRINT 'Table planned_route created';

    /* stop */
	EXEC('
		USE [nextstop_db];
		CREATE TABLE [dbo].[stop](
			[id] [varchar](10) IDENTITY(1,1) NOT NULL,
			[name] [varchar](50) NOT NULL,
			[longitude] [decimal](12,9) NOT NULL,
			[latitude] [decimal](12,9) NOT NULL,
			[type_id] [int] NOT NULL,
				CONSTRAINT [PK_stop] PRIMARY KEY ([id]))
	');
	PRINT 'Table stop created';

    /* route_stop */
	EXEC('
		USE [nextstop_db];
		CREATE TABLE [dbo].[route_stop](
			[route_id] [int] NOT NULL,
			[stop_id] [varchar](10) NOT NULL,
			[time_passed] [int] NOT NULL,
				CONSTRAINT [PK_route_stop] PRIMARY KEY (route_id, stop_id),
				CONSTRAINT [FK_route] FOREIGN KEY (route_id) REFERENCES route(id),
				CONSTRAINT [FK_stop] FOREIGN KEY (stop_id) REFERENCES stop(id))
	');
	PRINT 'Table route_stop created';

    /* drive/trip/journey/tour/ride */
	EXEC('
		USE [nextstop_db];
		CREATE TABLE [dbo].[trip](
			[id] [int] NOT NULL,
			[planned_route_id] [varchar](10) NOT NULL,
			[delay] [int] NOT NULL,
				CONSTRAINT [PK_trip] PRIMARY KEY CLUSTERED ([id]),
				CONSTRAINT [FK_planned_route] FOREIGN KEY (planned_route_id) REFERENCES planned_route(id))
	');
	PRINT 'Table trip created';

    /* stop_log */
	EXEC('
		USE [nextstop_db];
		CREATE TABLE [dbo].[stop_log](
			[id] [int] NOT NULL,
			[trip_id] [int] NOT NULL,
			[route_id] [int] NOT NULL,
			[stop_id] [varchar](10) NOT NULL,
				CONSTRAINT [PK_stop_log] PRIMARY KEY CLUSTERED ([id]),
				CONSTRAINT [FK_trip] FOREIGN KEY (trip_id) REFERENCES trip(id),
				CONSTRAINT [FK_route_stop] FOREIGN KEY (route_id, stop_id) REFERENCES route_stop(route_id, stop_id))
	');
	PRINT 'Table stop_log created';

    /* INSERTS */
	PRINT 'Table person filled with sample data';
END