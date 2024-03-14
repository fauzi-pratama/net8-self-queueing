using Apps.Models;
using Apps.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSingleton<IQueueingService<UserMessage>, QueueingService<UserMessage>>();
builder.Services.AddSingleton<IQueueingService<TransactionMessage>, QueueingService<TransactionMessage>>();
builder.Services.AddSingleton<IUserService, UserService>();
builder.Services.AddSingleton<ITransactionService, TransactionService>();

builder.Services.AddHostedService<UserWorkerService>();
builder.Services.AddHostedService<TransactionWorkerService>();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
