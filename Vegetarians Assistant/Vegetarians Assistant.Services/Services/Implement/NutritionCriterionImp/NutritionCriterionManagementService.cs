﻿using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Vegetarians_Assistant.Repo.Entity;
using Vegetarians_Assistant.Repo.Repositories.Interface;
using Vegetarians_Assistant.Services.ModelView;
using Vegetarians_Assistant.Services.Services.Interface.INutritionCriterion;

namespace Vegetarians_Assistant.Services.Services.Implement.NutritionCriterionManagementService
{
    public class NutritionCriterionManagementService : INutritionCriterionManagementService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public NutritionCriterionManagementService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<List<NutritionCriterionView>> GetAllNutritionCriteria()
        {
            try
            {
                var nutritions = (await _unitOfWork.NutritionCriterionRepository.GetAsync()).ToList();
                List<NutritionCriterionView> nutritionCriterionViews = new List<NutritionCriterionView>();

                foreach (var nutrition in nutritions)
                {
                    var nutritionView = new NutritionCriterionView()
                    {
                        CriteriaId = nutrition.CriteriaId,
                        Gender = nutrition.Gender,
                        AgeRange = nutrition.AgeRange,
                        BmiRange = nutrition.BmiRange,
                        Profession = nutrition.Profession,
                        ActivityLevel = nutrition.ActivityLevel,
                        Goal = nutrition.Goal,
                        Calcium = nutrition.Calcium,
                        Calories = nutrition.Calories,
                        Carbs = nutrition.Carbs,
                        Cholesterol = nutrition.Cholesterol,
                        Fat = nutrition.Fat,
                        Fiber = nutrition.Fiber,
                        Iron = nutrition.Iron,
                        Magnesium = nutrition.Magnesium,
                        Omega3 = nutrition.Omega3,
                        Protein = nutrition.Protein,
                        Sodium = nutrition.Sodium,
                        Sugars = nutrition.Sugars,
                        VitaminA = nutrition.VitaminA,
                        VitaminB = nutrition.VitaminB,
                        VitaminC = nutrition.VitaminC,
                        VitaminD = nutrition.VitaminD,
                        VitaminE = nutrition.VitaminE
                    };
                    nutritionCriterionViews.Add(nutritionView);
                }
                return nutritionCriterionViews;

            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<NutritionCriterionView?> GetNutritionCriteriaDetailByCriteriaId(int id)
        {

            try
            {
                var nutrition = await _unitOfWork.NutritionCriterionRepository.GetByIDAsync(id);
                if (nutrition != null)
                {
                    var nutritionCriteriaView = new NutritionCriterionView()
                    {
                        CriteriaId = nutrition.CriteriaId,
                        Gender = nutrition.Gender,
                        AgeRange = nutrition.AgeRange,
                        BmiRange = nutrition.BmiRange,
                        Profession = nutrition.Profession,
                        ActivityLevel = nutrition.ActivityLevel,
                        Goal = nutrition.Goal,
                        Calcium = nutrition.Calcium,
                        Calories = nutrition.Calories,
                        Carbs = nutrition.Carbs,
                        Cholesterol = nutrition.Cholesterol,
                        Fat = nutrition.Fat,
                        Fiber = nutrition.Fiber,
                        Iron = nutrition.Iron,
                        Magnesium = nutrition.Magnesium,
                        Omega3 = nutrition.Omega3,
                        Protein = nutrition.Protein,
                        Sodium = nutrition.Sodium,
                        Sugars = nutrition.Sugars,
                        VitaminA = nutrition.VitaminA,
                        VitaminB = nutrition.VitaminB,
                        VitaminC = nutrition.VitaminC,
                        VitaminD = nutrition.VitaminD,
                        VitaminE = nutrition.VitaminE
                    };
                    return nutritionCriteriaView;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<UserDetailNutritionCriterionView>> GetUserNutritionCriteriaByUserId(int userId)
        {
            try
            {
                // Lấy danh sách UsersNutritionCriterion theo UserId
                var userNutritionCriteriaList = await _unitOfWork.UsersNutritionCriterionRepository
                    .FindAsync(u => u.UserId == userId);

                if (!userNutritionCriteriaList.Any())
                {
                    return new List<UserDetailNutritionCriterionView>(); // Trả về danh sách rỗng nếu không có dữ liệu
                }

                // Khởi tạo danh sách kết quả
                List<UserDetailNutritionCriterionView> userDetailNutritionCriteriaViews = new List<UserDetailNutritionCriterionView>();

                foreach (var userNutrition in userNutritionCriteriaList)
                {
                    // Lấy thông tin NutritionCriterion từ bảng NutritionCriterion theo CriteriaId
                    var nutrition = await _unitOfWork.NutritionCriterionRepository
                        .GetByIDAsync(userNutrition.CriteriaId.GetValueOrDefault());

                    if (nutrition != null)
                    {
                        // Tạo UserDetailNutritionCriterionView và gán giá trị
                        var userDetailNutritionCriterionView = new UserDetailNutritionCriterionView()
                        {
                            UserNutritionCriteriaId = userNutrition.UserNutritionCriteriaId,
                            UserId = userNutrition.UserId,
                            CriteriaId = nutrition.CriteriaId,
                            Calories = nutrition.Calories,
                            Protein = nutrition.Protein,
                            Carbs = nutrition.Carbs,
                            Fat = nutrition.Fat,
                            Fiber = nutrition.Fiber,
                            VitaminA = nutrition.VitaminA,
                            VitaminB = nutrition.VitaminB,
                            VitaminC = nutrition.VitaminC,
                            VitaminD = nutrition.VitaminD,
                            VitaminE = nutrition.VitaminE,
                            Calcium = nutrition.Calcium,
                            Iron = nutrition.Iron,
                            Magnesium = nutrition.Magnesium,
                            Omega3 = nutrition.Omega3,
                            Sugars = nutrition.Sugars,
                            Cholesterol = nutrition.Cholesterol,
                            Sodium = nutrition.Sodium
                        };

                        // Thêm vào danh sách kết quả
                        userDetailNutritionCriteriaViews.Add(userDetailNutritionCriterionView);
                    }
                }

                return userDetailNutritionCriteriaViews;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> CreateNutritionCriteria(NutritionCriterionView newNutritionCriteria)
        {
            try
            {
                bool status = false;
                var nutrition = _mapper.Map<NutritionCriterion>(newNutritionCriteria);
                await _unitOfWork.NutritionCriterionRepository.InsertAsync(nutrition);
                await _unitOfWork.SaveAsync();
                var insertedNutritionCriteria = await _unitOfWork.NutritionCriterionRepository.GetByIDAsync(nutrition.CriteriaId);

                if (insertedNutritionCriteria != null)
                {
                    status = true;
                }

                return status;
            }
            catch (Exception ex)
            {
                var insertedNutritionCriteria = (await _unitOfWork.NutritionCriterionRepository.FindAsync(a => a.CriteriaId == newNutritionCriteria.CriteriaId)).FirstOrDefault();
                if (insertedNutritionCriteria != null)
                {
                    await _unitOfWork.NutritionCriterionRepository.DeleteAsync(insertedNutritionCriteria);
                    await _unitOfWork.SaveAsync();
                }
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> UpdateNutritionCriteriaByCriteriaId(NutritionCriterionView updateNutritionCriterion)
        {
            try
            {
                var exitsNutritionCriterion = (await _unitOfWork.NutritionCriterionRepository.FindAsync(c => c.CriteriaId == updateNutritionCriterion.CriteriaId)).FirstOrDefault();
                if (exitsNutritionCriterion == null)
                {
                    return false;
                }

                _mapper.Map(updateNutritionCriterion, exitsNutritionCriterion);
                await _unitOfWork.NutritionCriterionRepository.UpdateAsync(exitsNutritionCriterion);
                await _unitOfWork.SaveAsync();
                return true;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> DeleteNutritionCriteriaByCriteriaId(int id)
        {
            try
            {
                var nutritions = await _unitOfWork.NutritionCriterionRepository.GetByIDAsync(id);

                if (nutritions != null)
                {
                    
                    await _unitOfWork.NutritionCriterionRepository.DeleteAsync(nutritions);
                    await _unitOfWork.SaveAsync();
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
        }

    }
}
