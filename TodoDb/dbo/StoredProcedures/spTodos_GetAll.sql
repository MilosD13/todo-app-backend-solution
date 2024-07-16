CREATE PROCEDURE [dbo].[spTodos_GetAll]
	@AssignedTo int
AS
BEGIN
	SELECT Id, Task, AssignedTo, IsComplete
	FROM dbo.Todos
	WHERE AssignedTo = @AssignedTo;
END