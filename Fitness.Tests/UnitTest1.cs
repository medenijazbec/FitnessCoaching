using System;
using Xunit;
using Fitness.Classes;





namespace Fitness.Tests
{

    public class AppointmentTests
    {
        [Fact]
        public void Constructor_ValidDates_ShouldCreateAppointment()
        {
            // Arrange
            var startDate = DateTime.Now;
            var endDate = startDate.AddHours(1);
            var description = "Test Appointment";

            // Act
            var appointment = new Appointment(startDate, endDate, description);

            // Assert
            Assert.Equal(startDate, appointment.StartDate);
            Assert.Equal(endDate, appointment.EndDate);
            Assert.Equal(description, appointment.Description);
        }

        [Fact]
        public void Constructor_EndDateBeforeStartDate_ShouldThrowArgumentException()
        {
            // Arrange
            var startDate = DateTime.Now;
            var endDate = startDate.AddHours(-1);

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Appointment(startDate, endDate, "Invalid Appointment"));
            Assert.Equal("EndDate must be greater than StartDate.", exception.Message);
        }

        [Fact]
        public void ConflictsWith_OverlappingAppointments_ShouldReturnTrue()
        {
            // Arrange
            var startDate1 = DateTime.Now;
            var endDate1 = startDate1.AddHours(2);
            var appointment1 = new Appointment(startDate1, endDate1, "Appointment 1");

            var startDate2 = startDate1.AddHours(1);
            var endDate2 = startDate2.AddHours(2);
            var appointment2 = new Appointment(startDate2, endDate2, "Appointment 2");

            // Act
            var doesConflict = appointment1.ConflictsWith(appointment2);

            // Assert
            Assert.True(doesConflict);
        }
    }

    public class DietItemTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateDietItem()
        {
            // Arrange
            var itemName = "Apple";
            var calories = 95;
            var proteins = 0.5f;
            var carbohydrates = 25f;
            var fats = 0.3f;
            var mealTime = DateTime.Now;

            // Act
            var dietItem = new DietItem(itemName, calories, proteins, carbohydrates, fats, mealTime);

            // Assert
            Assert.Equal(itemName, dietItem.ItemName);
            Assert.Equal(calories, dietItem.Calories);
            Assert.Equal(proteins, dietItem.Proteins);
            Assert.Equal(carbohydrates, dietItem.Carbohydrates);
            Assert.Equal(fats, dietItem.Fats);
            Assert.Equal(mealTime, dietItem.MealTime);
        }

        [Fact]
        public void CalculateCalories_ValidMacronutrients_ShouldReturnCorrectCalorieCount()
        {
            // Arrange
            var proteins = 10f;
            var carbohydrates = 20f;
            var fats = 5f;
            var expectedCalories = (int)((proteins * 4) + (carbohydrates * 4) + (fats * 9));

            // Act
            var calories = DietItem.CalculateCalories(proteins, carbohydrates, fats);

            // Assert
            Assert.Equal(expectedCalories, calories);
        }

        [Theory]
        [InlineData(-1, 0, 0)]
        [InlineData(0, -1, 0)]
        [InlineData(0, 0, -1)]
        public void Constructor_NegativeMacronutrients_ShouldThrowArgumentOutOfRangeException(float proteins, float carbohydrates, float fats)
        {
            // Arrange
            var itemName = "Invalid Item";
            var calories = 100; // Arbitrary calories value
            var mealTime = DateTime.Now;

            // Act & Assert
            var exception = Assert.Throws<ArgumentOutOfRangeException>(() => new DietItem(itemName, calories, proteins, carbohydrates, fats, mealTime));
            Assert.Contains("cannot be negative", exception.Message);
        }
    }

    public class DietPlanTests
    {
        [Fact]
        public void AddDietItem_ValidDietItem_ShouldBeAddedToList()
        {
            // Arrange
            var dietPlan = new DietPlan("Weight Loss Plan");
            var dietItem = new DietItem("Salad", 200, 5, 10, 2, DateTime.Now);

            // Act
            dietPlan.AddDietItem(dietItem);

            // Assert
            Assert.Contains(dietItem, dietPlan.DietItems);
        }

        [Fact]
        public void RemoveDietItem_ValidDietItem_ShouldBeRemovedFromList()
        {
            // Arrange
            var dietPlan = new DietPlan("Weight Loss Plan");
            var dietItem = new DietItem("Salad", 200, 5, 10, 2, DateTime.Now);
            dietPlan.AddDietItem(dietItem);

            // Act
            bool removed = dietPlan.RemoveDietItem(dietItem);

            // Assert
            Assert.True(removed);
            Assert.DoesNotContain(dietItem, dietPlan.DietItems);
        }

        [Fact]
        public void CalculateTotalCalories_MultipleDietItems_ShouldReturnSumOfCalories()
        {
            // Arrange
            var dietPlan = new DietPlan("Weight Loss Plan");
            dietPlan.AddDietItem(new DietItem("Salad", 200, 5, 10, 2, DateTime.Now));
            dietPlan.AddDietItem(new DietItem("Chicken Breast", 300, 30, 0, 5, DateTime.Now));
            var expectedTotalCalories = 500; // 200 for Salad + 300 for Chicken Breast

            // Act
            int totalCalories = dietPlan.CalculateTotalCalories();

            // Assert
            Assert.Equal(expectedTotalCalories, totalCalories);
        }
    }
    public class ExerciseTests
    {
        [Fact]
        public void Constructor_ValidParameters_ShouldCreateExercise()
        {
            // Arrange
            var name = "Push Up";
            var muscleGroupName = "Chest";
            var muscleGroup = new MuscleGroup(muscleGroupName);
            var repetitions = 10;
            var sets = 3;
            var restInterval = 60;

            // Act
            var exercise = new Exercise(name, muscleGroup, repetitions, sets, restInterval);

            // Assert
            Assert.Equal(name, exercise.Name);
            Assert.Equal(muscleGroup, exercise.TargetMuscleGroup);
            Assert.Equal(repetitions, exercise.Repetitions);
            Assert.Equal(sets, exercise.Sets);
            Assert.Equal(restInterval, exercise.RestInterval);
        }

        [Fact]
        public void UpdateRepetitions_ValidRepetitions_ShouldUpdateValue()
        {
            // Arrange
            var muscleGroupName = "Chest";
            var muscleGroup = new MuscleGroup(muscleGroupName);
            var exercise = new Exercise("Push Up", muscleGroup, 10, 3, 60);
            var newRepetitions = 12;

            // Act
            exercise.UpdateRepetitions(newRepetitions);

            // Assert
            Assert.Equal(newRepetitions, exercise.Repetitions);
        }

        [Fact]
        public void UpdateRestInterval_NegativeInterval_ShouldThrowArgumentException()
        {
            // Arrange
            var muscleGroupName = "Chest";
            var muscleGroup = new MuscleGroup(muscleGroupName);
            var exercise = new Exercise("Push Up", muscleGroup, 10, 3, 60);
            var newRestInterval = -10;

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => exercise.UpdateRestInterval(newRestInterval));
            Assert.Equal("Rest interval must not be negative.", exception.Message);
        }
    }


    public class MembershipTests
    {
        [Fact]
        public void Constructor_ValidDates_ShouldCreateMembership()
        {
            // Arrange
            var startDate = DateTime.Now;
            var endDate = startDate.AddMonths(1);
            var member = new User("john_doe", "password123"); // Create a User object with sample credentials

            // Act
            var membership = new Membership(startDate, endDate, member);

            // Assert
            Assert.Equal(startDate, membership.StartDate);
            Assert.Equal(endDate, membership.EndDate);
            Assert.Same(member, membership.Member);
        }

        [Fact]
        public void RenewMembership_ValidExtension_ShouldExtendEndDate()
        {
            // Arrange
            var startDate = DateTime.Now.AddDays(-10); // Started 10 days ago
            var endDate = startDate.AddMonths(1); // Ends in about 20 days
            var member = new User("john_doe", "password123"); // Create a User object with sample credentials
            var membership = new Membership(startDate, endDate, member);
            var extensionMonths = 6;

            // Act
            membership.RenewMembership(extensionMonths);

            // Assert
            var expectedEndDate = endDate.AddMonths(extensionMonths);
            Assert.Equal(expectedEndDate, membership.EndDate);
        }

        [Fact]
        public void AdjustStartDate_ValidNewStartDate_ShouldUpdateStartDate()
        {
            // Arrange
            var startDate = DateTime.Now.AddDays(-10); // Started 10 days ago
            var endDate = startDate.AddMonths(1); // Ends in about 20 days
            var member = new User("john_doe", "password123"); // Create a User object with sample credentials
            var membership = new Membership(startDate, endDate, member);
            var newStartDate = startDate.AddDays(-5); // Start 5 days earlier

            // Act
            membership.AdjustStartDate(newStartDate);

            // Assert
            Assert.Equal(newStartDate, membership.StartDate);
        }
    }

    public class MesocycleTests
    {
        [Fact]
        public void AddWorkoutSession_ValidSession_ShouldAddSession()
        {
            // Arrange
            var mesocycle = new Mesocycle("Strength Building", DateTime.Today, DateTime.Today.AddDays(90));
            var workoutSession = new WorkoutSession(
                "Leg Day",
                "Leg workouts",
                TimeSpan.FromHours(1),
                DifficultyLevel.Beginner,
                DateTime.Now,
                DateTime.Now.AddHours(1)
            );

            // Act
            mesocycle.AddWorkoutSession(workoutSession);

            // Assert
            Assert.Contains(workoutSession, mesocycle.WorkoutSessions);
        }

        [Fact]
        public void AddWorkoutSession_ConflictingSession_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var mesocycle = new Mesocycle("Strength Building", DateTime.Today, DateTime.Today.AddDays(90));
            var session1 = new WorkoutSession(
                "Leg Day",
                "Leg workouts",
                TimeSpan.FromHours(1),
                DifficultyLevel.Beginner,
                DateTime.Now,
                DateTime.Now.AddHours(1)
            );
            var session2 = new WorkoutSession(
                "Arm Day",
                "Arm workouts",
                TimeSpan.FromHours(1),
                DifficultyLevel.Intermediate,
                DateTime.Now.AddMinutes(30),
                DateTime.Now.AddHours(1).AddMinutes(30)
            );
            mesocycle.AddWorkoutSession(session1);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => mesocycle.AddWorkoutSession(session2));
            Assert.Equal("Workout session conflicts with an existing session.", exception.Message);
        }

        [Fact]
        public void RemoveWorkoutSession_ValidSession_ShouldRemoveSession()
        {
            // Arrange
            var mesocycle = new Mesocycle("Strength Building", DateTime.Today, DateTime.Today.AddDays(90));
            var workoutSession = new WorkoutSession(
                "Leg Day",
                "Leg workouts",
                TimeSpan.FromHours(1),
                DifficultyLevel.Beginner,
                DateTime.Now,
                DateTime.Now.AddHours(1)
            );
            mesocycle.AddWorkoutSession(workoutSession);

            // Act
            var result = mesocycle.RemoveWorkoutSession(workoutSession);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(workoutSession, mesocycle.WorkoutSessions);
        }
    }

    public class MuscleGroupTests
    {
        [Fact]
        public void AddExercise_ValidExercise_ShouldAddToMuscleGroup()
        {
            // Arrange
            var muscleGroup = new MuscleGroup("Chest");
            var exercise = new Exercise("Bench Press", muscleGroup, 10, 3, 60); // Assuming these are valid parameters for Exercise

            // Act
            muscleGroup.AddExercise(exercise);

            // Assert
            Assert.Contains(exercise, muscleGroup.Exercises);
        }

        [Fact]
        public void AddExercise_InvalidExercise_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var chestMuscleGroup = new MuscleGroup("Chest");
            var legMuscleGroup = new MuscleGroup("Legs");
            var exercise = new Exercise("Squats", legMuscleGroup, 10, 3, 60); // Assuming these are valid parameters for Exercise

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => chestMuscleGroup.AddExercise(exercise));
            Assert.Equal("Exercise targets a different muscle group.", exception.Message);
        }

        [Fact]
        public void FindExerciseByName_ValidName_ShouldReturnExercise()
        {
            // Arrange
            var muscleGroup = new MuscleGroup("Chest");
            var exercise1 = new Exercise("Bench Press", muscleGroup, 10, 3, 60); // Assuming valid parameters for Exercise
            var exercise2 = new Exercise("Chest Fly", muscleGroup, 10, 3, 60); // Assuming valid parameters for Exercise
            muscleGroup.AddExercise(exercise1);
            muscleGroup.AddExercise(exercise2);
            var searchName = "chest fly";

            // Act
            var foundExercise = muscleGroup.FindExerciseByName(searchName);

            // Assert
            Assert.Same(exercise2, foundExercise);
        }
    }

    public class PaymentTests
    {
        [Fact]
        public void Constructor_ValidAmount_ShouldCreatePayment()
        {
            // Arrange
            var payer = new User("john_doe", "password123"); // Assuming these are valid parameters for User
            var amount = 100m;
            var paymentDate = DateTime.Now;
            var paymentMethod = "Credit Card";

            // Act
            var payment = new Payment(payer, amount, paymentDate, paymentMethod);

            // Assert
            Assert.Equal(payer, payment.Payer);
            Assert.Equal(amount, payment.Amount);
            Assert.Equal(paymentDate, payment.PaymentDate);
            Assert.Equal(paymentMethod, payment.PaymentMethod);
        }

        [Fact]
        public void Constructor_NegativeAmount_ShouldThrowArgumentException()
        {
            // Arrange
            var payer = new User("john_doe", "password123"); // Create a User object with sample credentials
            var amount = -100m; // Invalid amount

            // Act & Assert
            var exception = Assert.Throws<ArgumentException>(() => new Payment(payer, amount, DateTime.Now, "Credit Card"));
            Assert.Equal("Amount must be greater than zero.", exception.Message);
        }

        [Fact]
        public void GeneratePaymentReport_ValidCall_ReturnsExpectedString()
        {
            // Arrange
            var payer = new User("john_doe", "password123"); // Create a User object with sample credentials
            var payment = new Payment(payer, 100m, DateTime.Now, "Credit Card");
            var expectedReport = $"Payment Report -- Payer: {payer.Username}, Amount: 100, Date: {payment.PaymentDate}, Method: Credit Card";

            // Act
            var report = payment.GeneratePaymentReport();

            // Assert
            Assert.Equal(expectedReport, report);
        }
    }

    public class ProgressRecordTests
    {
        [Fact]
        public void AddMeasurement_ValidData_ShouldAddMeasurement()
        {
            // Arrange
            var progressRecord = new ProgressRecord(DateTime.Now, "Week 1 Progress");
            var key = "Weight";
            var value = 70.5; // Example weight in kg

            // Act
            progressRecord.AddMeasurement(key, value);

            // Assert
            Assert.True(progressRecord.Measurements.ContainsKey(key));
            Assert.Equal(value, progressRecord.Measurements[key]);
        }

        [Fact]
        public void GetMeasurement_ValidKey_ReturnsValue()
        {
            // Arrange
            var progressRecord = new ProgressRecord(DateTime.Now, "Week 1 Progress");
            var key = "Weight";
            var value = 70.5; // Example weight in kg
            progressRecord.AddMeasurement(key, value);

            // Act
            var retrievedValue = progressRecord.GetMeasurement(key);

            // Assert
            Assert.Equal(value, retrievedValue);
        }

        [Fact]
        public void GetMeasurement_InvalidKey_ThrowsKeyNotFoundException()
        {
            // Arrange
            var progressRecord = new ProgressRecord(DateTime.Now, "Week 1 Progress");
            var invalidKey = "InvalidKey";

            // Act & Assert
            var exception = Assert.Throws<KeyNotFoundException>(() => progressRecord.GetMeasurement(invalidKey));
            Assert.Equal($"Measurement key '{invalidKey}' not found.", exception.Message);
        }
    }

    public class ProgressTrackerTests
    {
        [Fact]
        public void AddProgressRecord_ValidRecord_ShouldAddRecord()
        {
            // Arrange
            var user = new User("john_doe", "password123");
            var progressTracker = new ProgressTracker(user);
            var record = new ProgressRecord(DateTime.Now, "Progress Note");

            // Act
            progressTracker.AddProgressRecord(record);

            // Assert
            Assert.Contains(record, progressTracker.ProgressRecords);
        }

        [Fact]
        public void RemoveProgressRecord_ValidRecord_ShouldRemoveRecord()
        {
            // Arrange
            var user = new User("john_doe", "password123");
            var progressTracker = new ProgressTracker(user);
            var record = new ProgressRecord(DateTime.Now, "Progress Note");
            progressTracker.AddProgressRecord(record);

            // Act
            var result = progressTracker.RemoveProgressRecord(record);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(record, progressTracker.ProgressRecords);
        }

        [Fact]
        public void FindRecordByDate_ValidDate_ReturnsRecord()
        {
            // Arrange
            var user = new User("john_doe", "password123");
            var progressTracker = new ProgressTracker(user);
            var date = DateTime.Today;
            var record = new ProgressRecord(date, "Progress Note");
            progressTracker.AddProgressRecord(record);

            // Act
            var foundRecord = progressTracker.FindRecordByDate(date);

            // Assert
            Assert.Equal(record, foundRecord);
        }

        [Fact]
        public void AnalyzeProgress_WithValidData_ReturnsAnalysis()
        {
            // Arrange
            var user = new User("john_doe", "password123");
            var progressTracker = new ProgressTracker(user);
            var measurementKey = "Weight";
            var record1 = new ProgressRecord(DateTime.Now.AddDays(-1), "Progress Note");
            record1.AddMeasurement(measurementKey, 75); // 75 kg
            var record2 = new ProgressRecord(DateTime.Now, "Progress Note");
            record2.AddMeasurement(measurementKey, 76); // 76 kg
            progressTracker.AddProgressRecord(record1);
            progressTracker.AddProgressRecord(record2);

            // Act
            var analysis = progressTracker.AnalyzeProgress(measurementKey);

            // Assert
            Assert.Contains("Average change in 'Weight': 1", analysis);
        }
    }

    public class ReservationTests
    {
        [Fact]
        public void Constructor_ValidData_ShouldCreateReservation()
        {
            // Arrange
            var member = new User("john_doe", "password123");
            var appointment = new Appointment(DateTime.Now, DateTime.Now.AddHours(1), "Gym Session");

            // Act
            var reservation = new Reservation(member, appointment);

            // Assert
            Assert.Equal(member, reservation.Member);
            Assert.Equal(appointment, reservation.Appointment);
            Assert.False(reservation.IsConfirmed);
        }

        [Fact]
        public void Confirm_Reservation_ShouldSetIsConfirmedToTrue()
        {
            // Arrange
            var member = new User("john_doe", "password123");
            var appointment = new Appointment(DateTime.Now, DateTime.Now.AddHours(1), "Gym Session");
            var reservation = new Reservation(member, appointment);

            // Act
            reservation.Confirm();

            // Assert
            Assert.True(reservation.IsConfirmed);
        }

        [Fact]
        public void Reschedule_ConfirmedReservation_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var member = new User("john_doe", "password123");
            var appointment = new Appointment(DateTime.Now, DateTime.Now.AddHours(1), "Gym Session");
            var reservation = new Reservation(member, appointment);
            reservation.Confirm();
            var newAppointment = new Appointment(DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(1), "New Gym Session");

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => reservation.Reschedule(newAppointment));
            Assert.Equal("Cannot reschedule a confirmed appointment. Please cancel and create a new reservation.", exception.Message);
        }
    }

    public class ScheduleTests
    {
        [Fact]
        public void AddAppointment_NonConflictingAppointment_ShouldAddAppointment()
        {
            // Arrange
            var schedule = new Schedule();
            var appointment = new Appointment(DateTime.Now, DateTime.Now.AddHours(1), "Gym Session");

            // Act
            schedule.AddAppointment(appointment);

            // Assert
            Assert.Contains(appointment, schedule.Appointments);
        }

        [Fact]
        public void AddAppointment_ConflictingAppointment_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var schedule = new Schedule();
            var appointment1 = new Appointment(DateTime.Now, DateTime.Now.AddHours(1), "Gym Session 1");
            var appointment2 = new Appointment(DateTime.Now.AddMinutes(30), DateTime.Now.AddHours(1).AddMinutes(30), "Gym Session 2");
            schedule.AddAppointment(appointment1);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => schedule.AddAppointment(appointment2));
            Assert.Equal("Appointment conflicts with an existing appointment.", exception.Message);
        }

        [Fact]
        public void FindAppointmentsByDate_ValidDate_ReturnsAppointments()
        {
            // Arrange
            var schedule = new Schedule();
            var date = DateTime.Today;
            var appointment1 = new Appointment(date.AddHours(9), date.AddHours(10), "Morning Gym");
            var appointment2 = new Appointment(date.AddHours(14), date.AddHours(15), "Afternoon Gym");
            schedule.AddAppointment(appointment1);
            schedule.AddAppointment(appointment2);

            // Act
            var foundAppointments = schedule.FindAppointmentsByDate(date);

            // Assert
            var appointmentList = foundAppointments.ToList();
            Assert.Equal(2, appointmentList.Count);
            Assert.Contains(appointment1, appointmentList);
            Assert.Contains(appointment2, appointmentList);
        }
    }

    public class TrainerTests
    {
        [Fact]
        public void AddCertification_ValidCertification_ShouldAddCertification()
        {
            // Arrange
            var trainer = new Trainer("John Doe", "Fitness", 5);
            var certification = "CPR Certified";

            // Act
            trainer.AddCertification(certification);

            // Assert
            Assert.Contains(certification, trainer.Certifications);
        }

        [Fact]
        public void ScheduleAppointment_NonConflictingAppointment_ShouldAddAppointment()
        {
            // Arrange
            var trainer = new Trainer("John Doe", "Fitness", 5);
            var appointment = new Appointment(DateTime.Now, DateTime.Now.AddHours(1), "Training Session");

            // Act
            trainer.ScheduleAppointment(appointment);

            // Assert
            Assert.Contains(appointment, trainer.Schedule.Appointments);
        }

        [Fact]
        public void ScheduleAppointment_ConflictingAppointment_ShouldThrowInvalidOperationException()
        {
            // Arrange
            var trainer = new Trainer("John Doe", "Fitness", 5);
            var appointment1 = new Appointment(DateTime.Now, DateTime.Now.AddHours(1), "Training Session 1");
            var appointment2 = new Appointment(DateTime.Now.AddMinutes(30), DateTime.Now.AddHours(1).AddMinutes(30), "Training Session 2");
            trainer.ScheduleAppointment(appointment1);

            // Act & Assert
            var exception = Assert.Throws<InvalidOperationException>(() => trainer.ScheduleAppointment(appointment2));
            Assert.Equal("The appointment conflicts with an existing appointment.", exception.Message);
        }
    }

    public class TrainingCycleTests
    {
        [Fact]
        public void AddTrainingProgram_ValidProgram_ShouldAddProgram()
        {
            // Arrange
            var cycle = new TrainingCycle("Strength Cycle");
            var program = new TrainingProgram("Strength Program"); // Assuming this is a valid constructor call

            // Act
            cycle.AddTrainingProgram(program);

            // Assert
            Assert.Contains(program, cycle.TrainingPrograms);
        }

        [Fact]
        public void RemoveTrainingProgram_ValidProgram_ShouldRemoveProgram()
        {
            // Arrange
            var cycle = new TrainingCycle("Strength Cycle");
            var program = new TrainingProgram("Strength Program"); // Assuming this is a valid constructor call
            cycle.AddTrainingProgram(program);

            // Act
            var result = cycle.RemoveTrainingProgram(program);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(program, cycle.TrainingPrograms);
        }

        [Fact]
        public void FindTrainingProgramByName_ValidName_ReturnsProgram()
        {
            // Arrange
            var cycle = new TrainingCycle("Strength Cycle");
            var programName = "Strength Program";
            var program = new TrainingProgram(programName); // Assuming this is a valid constructor call
            cycle.AddTrainingProgram(program);

            // Act
            var foundProgram = cycle.FindTrainingProgramByName(programName);

            // Assert
            Assert.Equal(program, foundProgram);
        }
    }

    public class TrainingProgramTests
    {
        [Fact]
        public void AddWorkoutSession_ValidSession_ShouldAddSession()
        {
            // Arrange
            var program = new TrainingProgram("Strength Program");
            var session = new WorkoutSession("Leg Day", "Leg workouts", TimeSpan.FromHours(1), DifficultyLevel.Beginner, DateTime.Now, DateTime.Now.AddHours(1));

            // Act
            program.AddWorkoutSession(session);

            // Assert
            Assert.Contains(session, program.WorkoutSessions);
        }

        [Fact]
        public void RemoveWorkoutSession_ValidSession_ShouldRemoveSession()
        {
            // Arrange
            var program = new TrainingProgram("Strength Program");
            var session = new WorkoutSession("Leg Day", "Leg workouts", TimeSpan.FromHours(1), DifficultyLevel.Beginner, DateTime.Now, DateTime.Now.AddHours(1));
            program.AddWorkoutSession(session);

            // Act
            var result = program.RemoveWorkoutSession(session);

            // Assert
            Assert.True(result);
            Assert.DoesNotContain(session, program.WorkoutSessions);
        }

        [Fact]
        public void FindWorkoutSessions_ByPredicate_ShouldReturnMatchingSessions()
        {
            // Arrange
            var program = new TrainingProgram("Strength Program");
            var session1 = new WorkoutSession("Leg Day", "Leg workouts", TimeSpan.FromHours(1), DifficultyLevel.Beginner, DateTime.Now, DateTime.Now.AddHours(1));
            var session2 = new WorkoutSession("Arm Day", "Arm workouts", TimeSpan.FromHours(1.5), DifficultyLevel.Intermediate, DateTime.Now.AddDays(1), DateTime.Now.AddDays(1).AddHours(1.5));
            program.AddWorkoutSession(session1);
            program.AddWorkoutSession(session2);

            // Act
            var foundSessions = program.FindWorkoutSessions(s => s.Duration.TotalHours > 1);

            // Assert
            Assert.Contains(session2, foundSessions);
            Assert.DoesNotContain(session1, foundSessions);
        }
    }

    public class UserTests
    {
        [Fact]
        public void AddAppointment_ValidAppointment_ShouldBeAdded()
        {
            // Arrange
            var user = new User("john_doe", "password123");
            var appointment = new Appointment(DateTime.Now, DateTime.Now.AddHours(1), "Gym Session");

            // Act
            user.AddAppointment(appointment);
            var appointmentFound = user.FindProgressRecordByDate(appointment.StartDate);

            // Assert
            Assert.NotNull(appointmentFound);
        }

        [Fact]
        public void CancelAppointment_ValidAppointment_ShouldBeRemoved()
        {
            // Arrange
            var user = new User("john_doe", "password123");
            var appointment = new Appointment(DateTime.Now, DateTime.Now.AddHours(1), "Gym Session");
            user.AddAppointment(appointment);

            // Act
            var result = user.CancelAppointment(appointment);
            var appointmentFound = user.FindProgressRecordByDate(appointment.StartDate);

            // Assert
            Assert.False(result);
            Assert.Null(appointmentFound);
        }

        [Fact]
        public void ChangePassword_ValidNewPassword_ShouldChangePasswordHash()
        {
            // Arrange
            var user = new User("john_doe", "password123");
            var newPassword = "newPassword321";

            // Act
            user.ChangePassword(newPassword);

            // Assert
            Assert.True(user.CheckPassword(newPassword));
        }
    }

    public class WorkoutSessionTests
    {
        [Fact]
        public void AddExercise_ValidExercise_ShouldAddExercise()
        {
            // Arrange
            var workoutSession = new WorkoutSession("Cardio Session", "High-intensity interval training", TimeSpan.FromHours(1), DifficultyLevel.Advanced, DateTime.Now, DateTime.Now.AddHours(1));
            var muscleGroup = new MuscleGroup("Legs"); // Assuming MuscleGroup is a valid class
            var exercise = new Exercise("Running", muscleGroup, 10, 3, 60);

            // Act
            workoutSession.AddExercise(exercise);

            // Assert
            Assert.Contains(exercise, workoutSession.Exercises);
        }

        [Fact]
        public void ConflictsWith_OverlappingSession_ShouldReturnTrue()
        {
            // Arrange
            var session1 = new WorkoutSession("Morning Yoga", "Yoga and stretching", TimeSpan.FromHours(1), DifficultyLevel.Beginner, DateTime.Today.AddHours(9), DateTime.Today.AddHours(10));
            var session2 = new WorkoutSession("Mid-Morning Yoga", "Yoga and relaxation", TimeSpan.FromHours(1), DifficultyLevel.Intermediate, DateTime.Today.AddHours(9).AddMinutes(30), DateTime.Today.AddHours(10).AddMinutes(30));

            // Act
            var result = session1.ConflictsWith(session2);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void CalculateTotalIntensity_NoExercises_ReturnsZero()
        {
            // Arrange
            var session = new WorkoutSession("Evening Strength", "Strength training", TimeSpan.FromHours(2), DifficultyLevel.Advanced, DateTime.Now, DateTime.Now.AddHours(2));

            // Act
            var intensity = session.CalculateTotalIntensity();

            // Assert
            Assert.Equal(0, intensity);
        }
    }






















































































































}