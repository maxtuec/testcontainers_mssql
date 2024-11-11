USE [nextstop_db];

-- Insert sample data into the user table
INSERT INTO [dbo].[user] (user_name, password, user_type)
VALUES 
    ('Verkehrsunternehmen', 'admin123', 'admin'),
    ('Bus1', 'bus1', 'user'),
    ('Bus2', 'bus2', 'user'),
    ('Bus3', 'bus3', 'user');

-- Insert sample data into the type_of_day table
INSERT INTO [dbo].[type_of_day] (name)
VALUES 
    ('Weekday'),
    ('Weekend'),
    ('Holiday'),
    ('School Holiday');

-- Insert sample data into the holiday table
INSERT INTO [dbo].[holiday] (name, start, [end], type_id)
VALUES 
    ('New Year', '2024-01-01', '2024-01-01', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Epiphany', '2024-01-06', '2024-01-06', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Easter Monday', '2024-04-01', '2024-04-01', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Labour Day', '2024-05-01', '2024-05-01', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Ascension Day', '2024-05-09', '2024-05-09', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Whit Monday', '2024-05-20', '2024-05-20', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Corpus Christi', '2024-05-30', '2024-05-30', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Assumption of the Virgin Mary', '2024-08-15', '2024-08-15', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('National Day', '2024-10-26', '2024-10-26', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('All Saints Day', '2024-11-01', '2024-11-01', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Immaculate Conception', '2024-12-08', '2024-01-08', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Christmas Day', '2024-12-25', '2024-12-25', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('St Stephens Day', '2024-12-26', '2024-12-26', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('New Year', '2025-01-01', '2025-01-01', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Epiphany', '2025-01-06', '2025-01-06', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Easter Monday', '2025-04-21', '2025-04-21', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Labour Day', '2025-05-01', '2025-05-01', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Ascension Day', '2025-05-29', '2025-05-29', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Whit Monday', '2025-06-09', '2025-06-09', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Corpus Christi', '2025-06-19', '2025-06-19', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Assumption of the Virgin Mary', '2025-08-15', '2025-08-15', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('National Day', '2025-10-26', '2025-10-26', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('All Saints Day', '2025-11-01', '2025-11-01', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Immaculate Conception', '2025-12-08', '2025-01-08', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Christmas Day', '2025-12-25', '2025-12-25', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('St Stephens Day', '2025-12-26', '2025-12-26', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('Semester Holidays', '2024-02-17', '2025-02-22', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('Easter Holidays', '2024-04-12', '2024-04-21', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('Pentecost Holidays', '2024-06-07', '2024-05-09', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('Summer Holidays', '2024-07-05', '2024-09-07', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('Autumn Holidays', '2024-10-28', '2024-10-31', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('Christmas Holidays', '2024-12-23', '2025-01-06', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('Semester Holidays', '2025-02-17', '2025-02-22', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('Easter Holidays', '2025-04-12', '2025-04-21', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('Pentecost Holidays', '2025-06-07', '2025-05-09', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('Summer Holidays', '2025-07-05', '2025-09-07', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('Autumn Holiday', '2025-10-28', '2025-10-31', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('Christmas Holidays', '2025-12-23', '2026-01-06', (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday'));

-- Insert sample data into the route table
INSERT INTO [dbo].[route] (id, valid_from, valid_until)
VALUES 
    (350, '2024-01-01', '2024-12-31'),
    (353, '2024-01-01', '2024-06-30'),
    (373, '2024-07-01', '2024-12-31');

-- Insert sample data into the planned_route table
INSERT INTO [dbo].[planned_route] (start_time, route_id, type_id)
VALUES 
    ('08:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('10:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('12:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('14:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('16:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('18:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('08:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekend')),
    ('12:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekend')),
    ('16:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekend')),
    ('18:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekend')),
    ('08:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('14:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('18:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('12:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('16:00:00', 350, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('08:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('10:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('12:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('14:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('16:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('18:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('08:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekend')),
    ('12:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekend')),
    ('16:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekend')),
    ('18:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekend')),
    ('08:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('14:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('18:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('12:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('16:00:00', 353, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('08:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('10:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('12:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('14:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('16:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('18:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekday')),
    ('08:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekend')),
    ('12:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekend')),
    ('16:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekend')),
    ('18:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Weekend')),
    ('08:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('14:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('18:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'School Holiday')),
    ('12:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday')),
    ('16:00:00', 373, (SELECT id FROM [dbo].[type_of_day] WHERE name = 'Holiday'));

-- Insert sample data into the stop table
INSERT INTO [dbo].[stop] (id, name, longitude, latitude)
VALUES 
    ('PSB', 'Perg Schulzentrum Bahnhst', 48.2425970200295, 14.640397455361182),
    ('PSW', 'Perg Severinweg', 48.24479838009745, 14.639244415917863),
    ('PSP', 'Perg Schwemmplatzstraße', 48.24675074049534, 14.639575994787005),
    ('PHS', 'Perg Herrenstraße', 48.24940292595064, 14.636968982287016),
    ('PZT', 'Perg Zeitling', 48.2521469444157, 14.618239835372425),
    ('PWS', 'Perg Weinzierl Süd', 48.25129755387341, 14.603531385153435),
    ('PWG', 'Perg Weinzierl Gewerbegebiet', 48.25264059955385, 14.597995306141707),
    ('AAB', 'Aisthofen Abzw Bahnst', 48.25700798322676, 14.591625739178154),
    ('AAD', 'Aisthofen Am Dachsberg', 48.26157696434746, 14.589540081637548),
    ('SPS', 'Schwertberg Perger Straße', 48.26686080704364, 14.584798268143738);

INSERT INTO [dbo].[stop] (id, name, longitude, latitude)
VALUES 
    --('', 'Herrenstrasse', ),
    ('PMS', 'Perg Münzbacher Straße', 48.25259813306153, 14.646739373834189),
    ('PPS', 'Perg Poschachersiedlung', 48.257109547971396, 14.645400725748095),
    ('PKB', 'Perg Karlingberg', 48.25873097216882, 14.648674912254178),
    ('PPW', 'Pasching Perg Abzw Windhaag', 48.260859516635705, 14.651164002408633),
    ('PPO', 'Pasching Perg Ort', 48.26010953625241, 14.65519804469486),
    ('FOO', 'Forndorf Ort', 48.26203595524971, 14.66873412800961),
    ('FOS', 'Forndorf Schmiedkurve', 48.26339673626036, 14.6740078704415),
    ('AHO', 'Altenburg Honeder', 48.265990766292994, 14.679581069411647),
    ('ALO', 'Altenburg Ort',48.26846256492214, 14.688384719672996 );

    

INSERT INTO [dbo].[stop] (id, name, longitude, latitude)
VALUES 
    -- ('SPS', 'Schwertberg Perger Straße', 48.26686080704364, 14.584798268143738);
    ('SFE', 'Schwertberg Fa. Engel', 48.27113644469993, 14.58148778250625),
    ('SFR', 'Schwertberg Poneggen Roseggerstraße', 48.26930464885847, 14.570673913474058),
    ('SFB', 'Schwertberg Poneggen Bachstraße', 48.271714793358, 14.563317726968533),
    ('NZM', 'Niederzirking Orstmitte', 48.267383939302974, 14.551148455803656),
    ('NZB', 'Niederzirking B123', 48.26895441922498, 14.546245776200458),
    ('RRS', 'Ried in der Riedmark Schulen', 48.268785652815545, 14.529023378527286),
    ('RRM', 'Ried in der Riedmark Marktplatz', 48.271017218967245, 14.52789454046297),
    ('DRM', 'Danndorf Riedmark Mitte', 48.27721049729377, 14.512941811627883),
    ('DRO', 'Danndorf Riedmark Ort', 48.27899377301309, 14.50370872696871),
    ('DRH', 'Danndorf Riedmark Hanlkreuz', 48.28122752493258, 14.498984769298525);


-- Insert sample data into the route_stop table
INSERT INTO [dbo].[route_stop] (route_id, stop_id, time_passed)
VALUES 
    (350, 'SPS', 0),
    (350, 'AAD', 1),
    (350, 'AAB', 1),
    (350, 'PWG', 1),
    (350, 'PWS', 1),
    (350, 'PZT', 1),
    (350, 'PHS', 2),
    (350, 'PSP', 1),
    (350, 'PSW', 1),
    (350, 'PSB', 2),
    (373, 'PHS', 0),
    (373, 'PMS', 1),
    (373, 'PPS', 1),
    (373, 'PKB', 1),
    (373, 'PPW', 2),
    (373, 'PPO', 1),
    (373, 'FOO', 1),
    (373, 'FOS', 1),
    (373, 'AHO', 1),
    (373, 'ALO', 1),
    (353, 'SPS', 0),
    (353, 'SFE', 1),
    (353, 'SFR', 2),
    (353, 'SFB', 1),
    (353, 'NZM', 1),
    (353, 'NZB', 2),
    (353, 'RRS', 1),
    (353, 'RRM', 1),
    (353, 'DRM', 1),
    (353, 'DRO', 1),
    (353, 'DRH', 1);
    

-- Insert sample data into the trip table
INSERT INTO [dbo].[trip] (planned_route_id, delay)
VALUES 
    (1, 0),
    (2, 10),
    (3, 5);

-- Insert sample data into the stop_log table
INSERT INTO [dbo].[stop_log] (trip_id, route_id, stop_id)
VALUES 
    (1, 350, 'SPS'),
    (1, 350, 'AAD'),
    (1, 350, 'AAB');
