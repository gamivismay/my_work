# defining class
class Student():
    
    # defining constructor method
    def __init__(self, student_name, student_id):
        self.student_name = student_name        
        self.student_id = student_id
        
    # defining magic function to display string detial of student    
    def __str__(self):
        return f"Student name is {self.student_name} and student id is {self.student_id}."
    
    