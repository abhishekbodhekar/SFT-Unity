using Unity.Collections.LowLevel.Unsafe;
using UnityEngine.Audio;

public struct RegisterData 
{
        public string email;
        public string name;
        public string password;
        public string gender;
        public long age;
        public long height;
        public long weight;
}

public struct LoginClass {
            public string email;
        public string name;
        public string password;
}

public struct LoginResponse {
        public string error;
        public bool result;
        public RegisterData message;
}

public struct User {
       
        public float myBMI;
        public float dailyExercise  ;
        public string allergies  ;
        public string EatingHabitDropdown  ;
        public string medicalConsition  ;

}