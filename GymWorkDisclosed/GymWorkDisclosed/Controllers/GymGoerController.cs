using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BusinessLogic.Classes;
using BusinessLogic.Services.GymGoer;
using DAL.Repositories;
using GymWorkDisclosed.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GymWorkDisclosed.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GymGoerController : ControllerBase
    {
        private readonly GymGoerService _gymGoerService;
        
        public GymGoerController(GymGoerService gymGoerService)
        {
            _gymGoerService = gymGoerService;
        }
        // GET: api/GymGoer
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GymGoer/5
        [HttpGet("{id:guid}", Name = "GetWorkoutListByGymGoerId")]
        public IActionResult GetWorkoutListByGymGoerId(Guid id, string filterproperty, string filtervalue) 
        {
            try
            {
                GymGoer gymGoer = _gymGoerService.GetGymGoerById(id, filterproperty, filtervalue);
                GymGoerWorkoutsDTO gymGoerWorkoutsDTO = new GymGoerWorkoutsDTO(gymGoer.Id, gymGoer.Name, gymGoer.Email);
                foreach (Workout workout in gymGoer.Workouts)
                {
                    WorkoutDTO workoutDto = new WorkoutDTO(workout.Id, workout.Time, workout.Date);
                    workoutDto.Exercise = new ExerciseDTO(workout.Exercise.Id, workout.Exercise.Name);
                    foreach (MuscleGroup muscleGroup in workout.Exercise.MuscleGroups)
                    {
                        MuscleGroupDTO muscleGroupDto = new MuscleGroupDTO(muscleGroup.Id, muscleGroup.Name);
                        muscleGroupDto.Bodypart = new BodypartDTO(muscleGroup.BodyPart.Id, muscleGroup.BodyPart.Name);
                        workoutDto.Exercise.MuscleGroups.Add(muscleGroupDto);
                    }
                    foreach (Set set in workout.Sets)
                    {
                        workoutDto.Sets.Add(new SetDTO(set.Id, set.Reps, set.Weight, set.Time));
                    }
                    gymGoerWorkoutsDTO.Workouts.Add(workoutDto);
                }
                return Ok(gymGoerWorkoutsDTO);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
          
        }

        // POST: api/GymGoer
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/GymGoer/5
        [HttpPut("{id:guid}")]
        public void Put(Guid id, [FromBody] string value)
        {
        }

        // DELETE: api/GymGoer/5
        [HttpDelete("{id:guid}")]
        public void Delete(Guid id)
        {
        }
    }
}
