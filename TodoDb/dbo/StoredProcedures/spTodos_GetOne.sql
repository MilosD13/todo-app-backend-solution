﻿CREATE PROCEDURE [dbo].[spTodos_GetOne]
	@AssignedTo int,
	@TodoId int
AS
BEGIN
	SELECT Id, Task, AssignedTo, IsComplete
	FROM dbo.Todos
	WHERE AssignedTo = @AssignedTo and Id = @TodoId;
END