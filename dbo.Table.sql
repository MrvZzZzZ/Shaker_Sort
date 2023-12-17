CREATE TABLE [dbo].[Table]
(
	[Id] INT          NOT NULL,
	[size_list] int		 null,
	[sort_status] binary NOT null,
	[list] varchar(MAX)    null,
	PRIMARY KEY CLUSTERED ([Id] ASC)
)
