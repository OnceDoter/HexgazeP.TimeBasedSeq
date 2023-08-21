using Microsoft.AspNetCore.Mvc;
using TimeBasedSequence;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<ITimeBasedSequence, TimeBasedSequence.TimeBasedSequence>();

var app = builder.Build();

app.MapGet("/next", (ITimeBasedSequence sequence) => sequence.Next());
app.MapGet("/next/{count:int}", (ITimeBasedSequence sequence, [FromRoute] int count) => sequence.Next(count));

app.Run();