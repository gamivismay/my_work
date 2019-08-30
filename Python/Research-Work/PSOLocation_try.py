
# coding: utf-8

# In[1]:


import random   
import math   


# In[2]:


SWARM_SIZE = 30
MAX_ITERATION = 10000
PROBLEM_DIMENSION = 2 
C1 = 2.0    
C2 = 2.0    
W_UPPERBOUND = 1.0  
W_LOWERBOUND = 0.0   
X_LOW = 10.0
X_HIGH = 40.0
VELOCITY_LOW = -4.0
VELOCITY_HIGH = 4.0
DEFINED_LOCATIONS = [[10,10],[40,10],[2,48],[10,40],[40,40]]
WEIGHTS = [1000000.0,1000000.0,100000.0,100000.0,1000000.0]
ERR_TOLERANCE = 1e-20
W = 0.5
PARTICLES = []   
G_BEST = 0.0   
G_BEST_LOCATION = []


# In[3]:


class Particle:
    
    def __init__(self):
        self.p_best = 0.0
        self.l_best = []
        self.location = []
        self.velocity = []
        self.fitness_value = 0.0
    
    def get_velocity(self):
        return self.velocity
    
    def set_velocity(self, new_velocity):
        self.velocity = new_velocity
    
    def get_location(self):
        return self.location
    
    def set_location(self, new_location):
        self.location = new_location
    
    def get_fitness_value(self):
        return self.fitness_value
    
    def set_fitness_value(self, new_fitness_value):
        self.fitness_value = new_fitness_value
    
    def get_p_best(self):
        return self.p_best
    
    def set_p_best(self, new_p_best):
        self.p_best = new_p_best
    
    def get_l_best(self):
        return self.l_best

    def set_l_best(self, new_l_best):
        self.l_best = new_l_best 


# In[4]:


def initialize_particles():
    global G_BEST
    global G_BEST_LOCATION
    global PARTICLES
    
    for i in range(SWARM_SIZE):
        
        p = Particle()
        
        loc = []
        for j in range(PROBLEM_DIMENSION):
            loc_value = X_LOW + random.random() * (X_HIGH - X_LOW)
            loc.append(loc_value)
            
        vel = []
        for j in range(PROBLEM_DIMENSION):
            vel_value = VELOCITY_LOW + random.random() * (VELOCITY_HIGH - VELOCITY_LOW)
            vel.append(vel_value)
            
        p.set_location(loc)    
        p.set_velocity(vel)    
        p.set_fitness_value(evaluate(loc))   
        p.set_p_best(p.get_fitness_value())
        p.set_l_best(loc)    
        
        if i == 0:
            G_BEST = p.get_fitness_value()
            G_BEST_LOCATION = loc
        elif p.get_fitness_value() < G_BEST:
            G_BEST = p.get_fitness_value()
            G_BEST_LOCATION = loc
            
        PARTICLES.append(p)


# In[5]:


def optimize():
    global G_BEST
    global G_BEST_LOCATION
    global PARTICLES
    
    t = 0
    err = 9999
    
    while t < MAX_ITERATION and err > ERR_TOLERANCE:
        
        for i in range(SWARM_SIZE):
            r1 = random.random()
            r2 = random.random()
            
            p = PARTICLES[i]
            
            new_vel = []
            for j in range(PROBLEM_DIMENSION):
                new_vel_value = (W * p.get_velocity()[j]) + ((r1 * C1) * (p.get_l_best()[j] - p.get_location()[j])) + ((r2 * C2) * (G_BEST_LOCATION[j] - p.get_location()[j]))  
                new_vel.append(new_vel_value)
                
            p.set_velocity(new_vel)
            
            new_loc = []
            for j in range(PROBLEM_DIMENSION):
                new_position_value = p.get_location()[j] + new_vel[j]
                if new_position_value < X_LOW:
                    new_position_value = X_LOW
#                     new_position_value = X_LOW + random.uniform(0.1,0.2)
                if new_position_value > X_HIGH:
                    new_position_value = X_HIGH
#                     new_position_value = X_HIGH + random.uniform(0.1,0.2)
                new_loc.append(new_position_value)
            
            p.set_location(new_loc)  
            p.set_fitness_value(evaluate(new_loc)) 
            
            if p.get_fitness_value() < p.get_p_best():
                p.set_p_best(p.get_fitness_value())
                p.set_l_best(new_loc)
            
            if p.get_fitness_value() < G_BEST:
                G_BEST = p.get_fitness_value()
                G_BEST_LOCATION = new_loc
                
                print("{:15} {:20} {:20} {:20}".format(str(t), str(G_BEST_LOCATION[0]), str(G_BEST_LOCATION[1]), str(evaluate(G_BEST_LOCATION))))
            
        err = evaluate(G_BEST_LOCATION)
        t += 1
    return t
            


# In[6]:


def squared_distance(x,y,px,py):
    return (px - x) * (px - x) + (py - y) * (py - y)


# In[7]:


def evaluate(new_location):
    radiation = 0.0
    
    for i in range(len(DEFINED_LOCATIONS)):
        radiation += WEIGHTS[i] / squared_distance(DEFINED_LOCATIONS[i][0], DEFINED_LOCATIONS[i][1], new_location[0], new_location[1])
        
    return radiation  
        


# In[8]:


def main():
    print("{:15} {:20} {:20} {:20}".format("Iteration", "X", "Y", "Radiation"))
     
    initialize_particles()
    
    t = optimize()
    
    print("\nSolution found at iteration {}, the solution is: ".format(t-1))
    print("Best X: {}".format(G_BEST_LOCATION[0]))
    print("Best Y: {}".format(G_BEST_LOCATION[1]))
    print("Value: {}".format(evaluate(G_BEST_LOCATION)))
    


# In[9]:


main()

