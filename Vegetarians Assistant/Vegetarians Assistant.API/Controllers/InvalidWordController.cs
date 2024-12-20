﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Vegetarians_Assistant.API.Helpers;
using Vegetarians_Assistant.API.Requests;
using Vegetarians_Assistant.Repo.Repositories.Interface;
using Vegetarians_Assistant.Repo.Repositories.Repo;
using Vegetarians_Assistant.Services.ModelView;
using Vegetarians_Assistant.Services.Services.Interface.Admin;
using Vegetarians_Assistant.Services.Services.Interface.ArticleImp;
using Vegetarians_Assistant.Services.Services.Interface.IArticle;

namespace Vegetarians_Assistant.API.Controllers;

[Route("api/v1/invalid-word")]
[ApiController]
public class InvalidWordController(IInvalidWordService invalidWordService) : ControllerBase
{
    private readonly IInvalidWordService _invalidWordService = invalidWordService;

    [HttpGet("getall")] 
    public async Task<IActionResult> GetAllInvalidWord()
    {
        var list = await _invalidWordService.GetAllAsync();
        return Ok(list.OrderBy(x => x.Content));
    }

    [HttpPost("add")]
    public async Task<IActionResult> AddInvalidWord([FromBody] InValidWordRequest request)
    {
        var result = await _invalidWordService.AddAsync(request.Content);
        return Ok(result);
    }

    [HttpDelete("remove")]
    public async Task<IActionResult> RemoveInvalidWord([FromBody] InValidWordRequest request)
    {
        var result = await _invalidWordService.RemoveAsync(request.Content);
        return Ok(result);
    }

    [HttpPut("update")]
    public async Task<IActionResult> UpdateInvalidWord([FromBody] UpdateInvalidWordRequest request)
    {
        var result = await _invalidWordService.UpdateAsync(request.Content, request.NewContent);
        return Ok(result);
    }

    [HttpPost("check")]
    public async Task<IActionResult> CheckInvalidWord([FromBody] InValidWordRequest request)
    {
        var valid = await _invalidWordService.IsValidAsync(request.Content);
        return Ok(new ResponseView(valid, valid ? "Từ hợp lệ." : "Từ không hợp lệ."));
    }
}


