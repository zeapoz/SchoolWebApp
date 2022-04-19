using SchoolWebApp.Models;

namespace SchoolWebApp.Utility
{
    public static class Sorting
    {
        public static Student[] BubbleSort(IQueryable<Student> input) {
            Student[] arr = input.ToArray();

            for (int j = 0; j < arr.Length; j++)
            {
                for (int i = 0; i < arr.Length; i++)
                {
                    if (arr[j].LastName.CompareTo(arr[i].LastName) > 0) {
                        Student temp = arr[j];
                        arr[j] = arr[i];
                        arr[i] = temp;
                    }
                }
            }

            return arr;
        }
    }
}