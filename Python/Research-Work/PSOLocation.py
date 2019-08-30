
# coding: utf-8

# In[1]:


# importing all the packages needed
import random   
import math   


# In[2]:


# declaring all the global variables
SWARM_SIZE = 30  
MAX_ITERATION = 10000
PROBLEM_DIMENSION = 2 
C1 = 2.0    
C2 = 2.0    
W_UPPERBOUND = 1.0  
W_LOWERBOUND = 0.0  
PARTICLES = []   
G_BEST = 0.0   
G_BEST_LOCATION = [] 


# In[3]:


# creating class for particles
class Particle:
    
    # particle class construtor to initialize class and default values
    def __init__(self):
        # initializing default values
        self.p_best = 0.0
        self.l_best = []
        self.location = []
        self.velocity = []
        self.fitness_value = 0.0
    
    # function to get current value of velocity
    def get_velocity(self):
        return self.velocity
    
    # function to set new value of velocity
    def set_velocity(self, new_velocity):
        self.velocity = new_velocity
    
    # function to get current value to location
    def get_location(self):
        return self.location
    
    # function to set new value of location
    def set_location(self, new_location):
        self.location = new_location
    
    # function to get current value of fitness_value
    def get_fitness_value(self):
        return self.fitness_value
    
    # function so set new value of fitness_value
    def set_fitness_value(self, new_fitness_value):
        self.fitness_value = new_fitness_value
    
    # function to get current value of p_best value
    def get_p_best(self):
        return self.p_best
    
    # function to set new value of p_best value
    def set_p_best(self, new_p_best):
        self.p_best = new_p_best
    
    # function to get current value of l_best
    def get_l_best(self):
        return self.l_best

    # function ot set new value of l_best
    def set_l_best(self, new_l_best):
        self.l_best = new_l_best 


# In[4]:


# creating class for problem set values
class ProblemSet:
    
     # probelm set class construtor to initialize class and default values
    def __init__(self):
        #initializing default values
        self.constraints = [Constraint(10.0,40.0,-4.0,4.0),Constraint(10.0,40.0,-4.0,4.0)]
        self.locations = [[10,10],[40,10],[2,48],[10,40],[40,40]]
        self.weights = [1000000.0,1000000.0,100000.0,100000.0,1000000.0]
        self.err_tolerance = 1e-20
        
    # defining function to calculate squared_distance value using location x,y values
    def squared_distance(self, x, y, px, py):
        return (px - x) * (px - x) + (py - y) * (py - y)
    
    # defining function to evaluate radiation value
    def evaluate(self, location):
        radiation = 0.0
        
        for i in range(len(self.locations)):
            loc = self.locations[i]
            value = self.squared_distance(loc[0], loc[1], location[0], location[1])
            radiation += self.weights[i] / value
        
        return radiation


# In[5]:


# creating class for setting up constraint values
class Constraint:
    
    # constraint class construtor to initialize class and default values
    def __init__(self, x_low, x_high, velocity_low, velocity_high):
        self.x_low = x_low
        self.x_high = x_high
        self.velocity_low = velocity_low
        self.velocity_high = velocity_high
        
    # function to get current value of x_low value
    def get_x_low(self):
        return self.x_low
        
    # function to get current value of x_high value
    def get_x_high(self):
        return self.x_high
        
    # function to get current value of velocity_low value
    def get_velocity_low(self):
        return self.velocity_low
        
    # function to get current value of velocity_high value
    def get_velocity_high(self):
        return self.velocity_high


# In[6]:


# defining function to initialize all the values of particle randomly to start PSO
def initialize_particles():
    global G_BEST
    global G_BEST_LOCATION
    global PARTICLES
    
    for i in range(SWARM_SIZE):
        # creating new object for each and every particle depending on swarm size
        p = Particle()
        
        
        # randomize location inside a space defined in problem set
        loc = []    # list to store location value x, y
        for j in range(PROBLEM_DIMENSION):
            ps_loc = ProblemSet()   # creating object of problem set class
            # formula to calculate new values of x and y for location and storing in list
            new_loc_value = ps_loc.constraints[j].get_x_low() + random.random() * (ps_loc.constraints[j].get_x_high() - ps_loc.constraints[j].get_x_low())
            loc.append(new_loc_value)
            
        # randomize location inside a space defined in problem set
        vel = []    # list to store velocity value
        for j in range(PROBLEM_DIMENSION):
            ps_vel = ProblemSet() # creating object of problem set class
            # formula to calculate new values of velocity and storing in list
            vel_value = ps_vel.constraints[j].get_velocity_low() + random.random() * (ps_vel.constraints[j].get_velocity_high() - ps_vel.constraints[j].get_velocity_low())
            vel.append(vel_value)
            
        
        p.set_location(loc)    # setting new location in p object
        p.set_velocity(vel)    # setting new velocity in p object
        p.set_fitness_value(ProblemSet().evaluate(loc))    # calculating and setting fitness value in object p
        p.set_p_best(p.get_fitness_value())    # setting p_best value to be new fitness value in object p
        p.set_l_best(loc)    # setting new location in l_best
        
        # updating G-BEST and G_BEST_LOCATION values
        if i == 0:
            G_BEST = p.get_fitness_value()
            G_BEST_LOCATION = loc
        elif p.get_fitness_value() < G_BEST:
            G_BEST =  p.get_fitness_value()
            G_BEST_LOCATION = loc
            
        # adding particles in PARTICLES list
        PARTICLES.append(p)
        


# In[7]:


# function to calculate optimized value at each iteration
def optimize():
    global G_BEST
    global G_BEST_LOCATION
    global PARTICLES
    
    # declaring default variables
    t = 0
    err = 9999
    
    # using while loop till maximum iteration defined
    while t < MAX_ITERATION and err > ProblemSet().err_tolerance:
        
        # calculating value of w that is inertia
        w = W_UPPERBOUND - (t/MAX_ITERATION) * (W_UPPERBOUND - W_LOWERBOUND)
        
        # using for loop for all particles to update all the values of location, velocity, fitness value
        for i in range(SWARM_SIZE):
            # generate and store random values in r1 and r2
            r1 = random.random()
            r2 = random.random()
            
            # storing object refernce of each particle to update the values
            p = PARTICLES[i]
            
            # updating velocity for each particle
            new_vel = []    # list to store updated velocity
            for j in range(PROBLEM_DIMENSION):
                new_vel_value = (w * p.get_velocity()[j]) + (r1 * C1) * (p.get_l_best()[j] - p.get_location()[j]) + (r2 * C2) * (G_BEST_LOCATION[j] - p.get_location()[j])  
                new_vel.append(new_vel_value)
            
            p.set_velocity(new_vel)    # updating new velocity for each particle
            
            # updating location for each particle
            new_loc = []
            for j in range(PROBLEM_DIMENSION):
                # updating new location value and storing in object
                new_position_value = p.get_location()[j] + new_vel[j]
                # setting the minimum and maximum position if necessary
                if new_position_value < ProblemSet().constraints[j].get_x_low():
                    new_position_value = ProblemSet().constraints[j].get_x_low() + random.uniform(0.1,0.2)
                if new_position_value > ProblemSet().constraints[j].get_x_high():
                    new_position_value = ProblemSet().constraints[j].get_x_high() + random.uniform(0.1,0.2)
                new_loc.append(new_position_value)
                
                
            p.set_location(new_loc)    # updating new location for each particle
            p.set_fitness_value(ProblemSet().evaluate(new_loc))    # updating fitness value according to new location
            
            # updating particle's personal best value and its location 
            if p.get_fitness_value() < p.get_p_best():
                p.set_p_best(p.get_fitness_value())
                p.set_l_best(new_loc)
            
            # updating fitness value according to global best value and location
            if p.get_fitness_value() < G_BEST:
                G_BEST = p.get_fitness_value()
                G_BEST_LOCATION = new_loc
                
                # printing result for each iteration with specific format
                print("{:15} {:20} {:20} {:20}".format(str(t), str(G_BEST_LOCATION[0]), str(G_BEST_LOCATION[1]), str(ProblemSet().evaluate(G_BEST_LOCATION))))
            
        err = ProblemSet().evaluate(G_BEST_LOCATION)
        t += 1
    return t


# In[8]:


# main function to run the program
def main():
    # specific print format
    print("{:15} {:20} {:20} {:20}".format("Iteration", "X", "Y", "Radiation"))
     
    # calling this function to initialize all the values    
    initialize_particles()
    
    # storing value at each iteration
    t = optimize()
    
    # creating object of problem set class
    ps = ProblemSet()
    
    # printing out final solution result
    print("Solution found at iteration {}, the solution is: ".format(t-1))
    print("Best X: {}".format(G_BEST_LOCATION[0]))
    print("Best Y: {}".format(G_BEST_LOCATION[1]))
    print("Value: {}".format(ps.evaluate(G_BEST_LOCATION)))
    


# In[9]:


main()

