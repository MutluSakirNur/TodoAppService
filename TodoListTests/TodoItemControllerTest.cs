using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Newtonsoft.Json;
using System.Data.Entity;
using System.Text;
using TodoListApi.Application.Common.Interfaces;
using TodoListApi.Application.TodoItems.Commands.CreateTodoTask;
using TodoListApi.Application.TodoItems.Commands.EditTodoTask;
using TodoListApi.Application.TodoItems.Queries.ListPendingTasks;
using TodoListApi.Data;
using TodoListApi.Infrastructure.Services;
using TodoListApi.Models;

namespace TodoListTests
{
    public class TodoItemControllerTest
    {
        [Fact]
        public async Task Add_EmptyTitleObjectPassed_ReturnsCannotBeEmptyAsync()
        {
            //Arange
            var dataTodo = A.Fake<ITodoContext>();

            CreateTodoTaskCommand command = new("",DateTime.Now);
            CreateTodoTaskCommandHandler handler = new(dataTodo);

            //Act
            CreateTodoTaskCommandDto x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Assert
            Assert.Equal("Title cannot be empty", x.ErrorMessage);
        }

        [Fact]
        public async Task Edit_EmptyTitleObjectPassed_ReturnsCannotBeEmptyAsync()
        {
            //Arange
            var dataTodo = A.Fake<ITodoContext>();

            EditTodoTaskCommand command = new (1,"", DateTime.Now, false);
            EditTodoTaskCommandHandler handler = new(dataTodo);

            //Act
            EditTodoTaskCommandDto x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Assert
            Assert.Equal("Title cannot be empty", x.ErrorMessage);
        }

        [Fact]
        public async Task Add_CorrectObjectPassed_ReturnsIsSuccesfulAsync()
        {
            //Arange
            var dataTodo = A.Fake<ITodoContext>();

            CreateTodoTaskCommand command = new("TestTitle", DateTime.Now);
            CreateTodoTaskCommandHandler handler = new(dataTodo);

            //Act
            CreateTodoTaskCommandDto x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Assert
            Assert.True(x.IsSuccessful);

        }

        [Fact]
        public async Task Add_NullDateObjectPassed_ReturnsIsSuccesfulAsync()
        {
            //Arange
            var dataTodo = A.Fake<ITodoContext>();

            CreateTodoTaskCommand command = new("TestTitle",null);
            CreateTodoTaskCommandHandler handler = new(dataTodo);

            //Act
            CreateTodoTaskCommandDto x = await handler.Handle(command, new System.Threading.CancellationToken());

            //Assert
            Assert.True(x.IsSuccessful);

        }
    }
}