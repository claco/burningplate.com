
-----------------------------------------------------------------------------
-- restaurants
-----------------------------------------------------------------------------

DROP TABLE [restaurants];


CREATE TABLE [restaurants]
(
	[id] INTEGER  NOT NULL PRIMARY KEY,
	[name] VARCHAR(255),
	[created_at] TIMESTAMP,
	[updated_at] TIMESTAMP
);
