﻿using Microsoft.AspNetCore.Mvc;
using Vegetarians_Assistant.Services.ModelView;
using Vegetarians_Assistant.Services.Services.Interface.INutritionCriterion;

namespace Vegetarians_Assistant.API.Controllers
{
    public class NutritionCriterionController : ControllerBase
    {
        private readonly INutritionCriterionManagementService _nutritionCriterionManagementService;
        public NutritionCriterionController(INutritionCriterionManagementService nutritionCriterionManagementService)
        {
            _nutritionCriterionManagementService = nutritionCriterionManagementService;
        }

        [HttpGet("/api/v1/nutritionCriterions/allNutritionCriteria")]
        public async Task<ActionResult<IEnumerable<NutritionCriterionView>>> GetAllNutritionCriteria()
        {

            var nutritionCriterionsList = await _nutritionCriterionManagementService.GetAllNutritionCriteria();
            if (nutritionCriterionsList == null || !nutritionCriterionsList.Any())
            {
                return NotFound("No nutrition criterions found on the system");
            }
            return Ok(nutritionCriterionsList);
        }

        [HttpGet("/api/v1/nutritionCriterions/getNutritionCriteriaDetailByCriteriaId/{id}")]
        public async Task<ActionResult<NutritionCriterionView>> GetNutritionCriteriaDetailByCriteriaId(int id)
        {
            var nutritionCriterionsList = await _nutritionCriterionManagementService.GetNutritionCriteriaDetailByCriteriaId(id);
            if (nutritionCriterionsList == null)
            {
                return NotFound("Nutrition Criteria detail not found");
            }
            return Ok(nutritionCriterionsList);
        }

        [HttpPost("/api/v1/nutritionCriterions/createNutritionCriteria")]
        public async Task<IActionResult> CreateNutritionCriteria([FromBody] NutritionCriterionView newNutritionCriteria)
        {
            bool checkNutritionCriteria = await _nutritionCriterionManagementService.CreateNutritionCriteria(newNutritionCriteria);
            if (checkNutritionCriteria)
            {
                return Ok("Create nutrition criteria success");
            }
            else
            {
                return BadRequest("Create nutrition criteria fail");
            }
        }

        [HttpPut("/api/v1/nutritionCriterions/updateNutritionCriteriaByCriteriaId")]
        public async Task<IActionResult> UpdateNutritionCriteriaByCriteriaId([FromBody] NutritionCriterionView updateNutritionCriterion)
        {
            try
            {
                var success = await _nutritionCriterionManagementService.UpdateNutritionCriteriaByCriteriaId(updateNutritionCriterion);

                if (success)
                {
                    return Ok("Nutrition criterion detail updated successfully");
                }
                else
                {
                    return NotFound("Nutrition criterion not found or failed to update nutrition criterion detail");
                }
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("/api/v1/nutritionCriterions/deleteNutritionCriteriaByCriteriaId/{id}")]
        public async Task<IActionResult> DeleteNutritionCriteriaByCriteriaId(int id)
        {
            var success = await _nutritionCriterionManagementService.DeleteNutritionCriteriaByCriteriaId(id);

            if (success)
            {
                return Ok("Delete nutrition criteria successfully");
            }
            else
            {
                return NotFound("Nutrition criteria not found or failed to delete");
            }
        }

    }
}