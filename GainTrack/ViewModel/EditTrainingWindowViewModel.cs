using GainTrack.Data.Entities;
using GainTrack.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace GainTrack.ViewModel
{
    public class EditTrainingWindowViewModel : BaseViewModel
    {
        public int ChoosenTrainingId { get; set; }
        private IExerciseService _exerciseService;
        private ITrainingHasExerciseService _trainingHasExerciseService;
        private ITraningService _trainingService;
        private IWeigthExerciseService _weigthExerciseService;
        private ICardioExerciseService _cardioExerciseService;
        

        private ObservableCollection<TrainingHasExercise> _exercisesOnTraining;
        public ObservableCollection<TrainingHasExercise> ExercisesOnTraining
        {
            get => _exercisesOnTraining;
            set
            {
                _exercisesOnTraining = value;
                OnPropertyChanged(nameof(ExercisesOnTraining));
            }
        }




        public EditTrainingWindowViewModel(ITrainingHasExerciseService trainingHasExerciseService, IExerciseService exerciseService, ITraningService traningService, IWeigthExerciseService weigthExerciseService, ICardioExerciseService cardioExerciseService, int trainingId)
        {
            _exerciseService = exerciseService;
            _trainingHasExerciseService = trainingHasExerciseService;
            _trainingService = traningService;
            _weigthExerciseService = weigthExerciseService;
            _cardioExerciseService = cardioExerciseService;
            ChoosenTrainingId = trainingId;
            _exercisesOnTraining = new ObservableCollection<TrainingHasExercise>();
            
        }

        public async Task LoadExercisesForTraining()
        {
            var loadedExercisesForTraining = await _trainingHasExerciseService.GetTrainingHasExerciseByTrainingIdAsync(ChoosenTrainingId);
            
            _exercisesOnTraining = new ObservableCollection<TrainingHasExercise>(loadedExercisesForTraining);
        }

    

    


    }
}
