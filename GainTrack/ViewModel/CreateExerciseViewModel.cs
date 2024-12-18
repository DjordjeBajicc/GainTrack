using GainTrack.Data.Entities;
using GainTrack.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GainTrack.ViewModel
{
    public class CreateExerciseViewModel : BaseViewModel
    {
        private readonly IExerciseService _exerciseService;
        private readonly IWeigthExerciseService _weigthExerciseService;
        private readonly ICardioExerciseService _cardioExerciseService;

        private string _name;

        public string Name 
        { 
            get => _name;
            set
            {
                _name = value;
                OnPropertyChanged(nameof(Name));
            }
            
        }

        private string _exerciseType;

        public string ExerciseType
        {
            get => _exerciseType;
            set
            {
                _exerciseType = value;
                OnPropertyChanged(nameof(ExerciseType));
            }
        }

        private string _description;

        public string Description
        {
            get => _description;
            set
            {
                _description = value;
                OnPropertyChanged(nameof(Description));
            }
        }

        public ICommand saveCommand { get; }

        public CreateExerciseViewModel(IExerciseService exerciseService, IWeigthExerciseService weigthExerciseService, ICardioExerciseService cardioExerciseService)
        {
            _exerciseService = exerciseService;
            _weigthExerciseService = weigthExerciseService;
            _cardioExerciseService = cardioExerciseService;
            saveCommand = new RelayCommand(Save);
        }

        private async void Save(object? obj)
        {
            if (_name != null && _exerciseType != null)
            {
                Exercise exercise = new Exercise
                {
                    Name = Name
                };
                if (_description == null)
                {
                    exercise.Details = _description;
                }
                exercise = await _exerciseService.AddExerciseAsync(exercise);
                if (_exerciseType.Equals("Weight"))
                {
                    WeightExercise weightExercise = new WeightExercise
                    {
                        ExerciseId = exercise.Id
                    };
                    //MessageBox.Show(weightExercise.ExerciseId.ToString());
                    await _weigthExerciseService.AddWeightExerciseAsync(weightExercise);
                }
                else
                {
                    CardioExercise cardio = new CardioExercise
                    {
                        ExerciseId = exercise.Id
                    };
                    //MessageBox.Show(cardio.ExerciseId.ToString());
                    await _cardioExerciseService.AddCardioExerciseAsync(cardio);
                }

                MessageBox.Show(App.Current.Resources["TheExercisWasSuccessfullyCreated"].ToString());
            }
            else
            {
                MessageBox.Show(App.Current.Resources["EnterTheNameOfTheExerciseAndSelectTheType"].ToString());
            }
        }
    }
}
