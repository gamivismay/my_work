
# coding: utf-8

# In[1]:


# all packages declaration

import random
import math


# In[2]:


# all global variables declaration

PARTICLE_COUNT = 10
V_MAX = 4
MAX_EPOCHS = 10000
BST_COUNT = 6
SP_COUNT = 8
TARGET = 86.63
X_LOCS = [7, 8, 10, 23, 33, 38, 39, 46]
Y_LOCS = [4, 12, 22, 26, 26, 32, 44, 46]
X_BST_LOCS = [3, 21, 34, 25, 33, 47]
Y_BST_LOCS = [9, 10, 18, 33, 35, 40]
global_best_distance = 0.0
particles = []


# In[3]:


class Particle:
    
    m_data = [0] * SP_COUNT
    mp_best = 0
    m_velocity = 0.0
    
    def __init__(self):
        self.mp_best = 0
        self.m_velocity = 0.0
        
    def compare_to(self, that):
        if self.get_p_best() < that.get_p_best():
            return 1
        elif self.get_p_best() > that.get_p_best():
            return -1
        else:
            return 0
    
    def get_data(self,index):
        return self.m_data[index]
    
    def set_data(self,index,value):
        self.m_data[index] = value
        
    def hand_off_count(self):
        hand_off_count = 0
        last_bst_index = 0
        
        for i in range(SP_COUNT):
            if i == 0:
                last_bst_index == self.m_data[0]
            elif last_bst_index != self.m_data[i]:
                hand_off_count += 1
                last_bst_index = self.m_data[i]
        
        return hand_off_count
    
    def hand_off_sequence(self):
        seq = ""
        
        for i in range(SP_COUNT):
            seq = seq + str(self.m_data[i]) + ","
            
        return seq
    
    def get_p_best(self):
        return self.mp_best
    
    def set_p_best(self,value):
        self.mp_best = value
    
    def get_velocity(self):
        return self.m_velocity
    
    def set_velocity(self,velocity_score):
        self.m_velocity = velocity_score


# In[4]:


class ProblemSet:
    k1 = 115
    k2 = 35
    zig_sqr = 3.0 * 3.0
    s_min = 15
    s_max = 10.5 * s_min
    a = 0.5
    p = 0.1
    
    def __init__(self):
        pass
        
    def get_benefit(self, index):
        nasp = 0
        tass = 0
        
        this_particle = Particle()
        this_particle = particles[index]
        
        num_hand_offs = 0
        last_bst = -1
        
        
        for i in range(SP_COUNT):
            x_bst_loc = X_BST_LOCS[this_particle.get_data(i)]
            y_bst_loc = Y_BST_LOCS[this_particle.get_data(i)]
            
            x_loc = X_LOCS[i]
            y_loc = Y_LOCS[i]
            f = random.random() * self.zig_sqr
            
            r = math.sqrt(math.pow(x_bst_loc - x_loc,2) + math.pow(y_bst_loc - y_loc,2))
            sij = self.k1 - self.k2 * math.log(r) + f
            
            if sij >= self.s_min:
                nasp += 1
                tass += sij
                
            if i == 0:
                last_bst = this_particle.get_data(i);
            elif last_bst != this_particle.get_data(i):
                num_hand_offs += 1
                last_bst = this_particle.get_data(i)
                
        cqsl = 0
        if nasp != 0:
            cqsl = (tass/nasp) - (self.s_min * (SP_COUNT - nasp) / (SP_COUNT * self.p))
        else:
            cqsl = - (self.s_min * (SP_COUNT - nasp) / (SP_COUNT * self.p))
            
        benefit = (1 - self.a) * cqsl - self.a * num_hand_offs
        
        this_particle.set_p_best(benefit)


# In[5]:


def initialize():
    p = ProblemSet()
    global global_best_distance
    for i in range(PARTICLE_COUNT):
        new_particle = Particle()
        for j in range(SP_COUNT):
            value = random.randint(0,BST_COUNT-1)
            new_particle.set_data(j,value)
        particles.append(new_particle)
        index = particles.index(new_particle)
        p.get_benefit(index)
        
    bubble_sort()
    get_velocity()
    global_best_distance = particles[0].get_p_best();
    print("{:10} {:25} {:15}".format("Iteration", "Distance", "HandoffCount"))             
    print("{:10} {:25} {:5} {:10}".format("0", str(global_best_distance), str(particles[0].hand_off_count()), particles[0].hand_off_sequence()))             
    


# In[6]:


def randomly_arrange(index):
    sp = random.randint(0,SP_COUNT-1)
    bst = random.randint(0,BST_COUNT-1)
    
    particles[index].set_data(sp,bst)


# In[7]:


def get_velocity():
    worst_results = 0
    v_value = 0.0
    
    worst_results = particles[PARTICLE_COUNT-1].get_p_best()
    
    for i in range(0, PARTICLE_COUNT):
        v_value = (V_MAX * particles[i].get_p_best())/worst_results
        
        if v_value > V_MAX:
            particles[i].set_velocity(V_MAX)
        elif v_value < 0.0:
            particles[i].set_velocity(0.0)
        else:
            particles[i].set_velocity(v_value)


# In[8]:


def update_particles():
    for i in range(1,PARTICLE_COUNT):
        changes = int(math.floor(abs(particles[i].get_velocity())))
        
        for j in range(0,changes):
            if random.choice([True,False]):
                randomly_arrange(i)
            copy_from_particle(i-1,1)
        
        problem_set = ProblemSet()
        problem_set.get_benefit(i)
        


# In[9]:


def print_best_solution():
    if particles[0].get_p_best() <= TARGET:
        print("\nTarget reached.")
    else:
        print("Target not reached.")
    
    temp_list = []
    for i in range(0,BST_COUNT):
        temp_list.append(str(particles[0].get_data(i)))
    print(f"Shortest Route: {','.join(temp_list)}")
    
    print(f"Distance: {particles[0].get_p_best()}")


# In[10]:


def copy_from_particle(source, destination):
    temp_index = random.randint(0,SP_COUNT-1)
    
    particles[destination].set_data(temp_index, particles[source].get_data(temp_index))


# In[11]:


def bubble_sort():
    done = False
    
    while not done:
        changes = 0
        list_size = len(particles)
        
        for i in range(0,list_size-1):
            if particles[i].compare_to(particles[i+1]) == 1:
                temp = particles[i]
                particles[i] = particles[i+1]
                particles[i+1] = temp
                changes += 1
        if changes == 0:
            done = True


# In[12]:


def pso_algorithm():
    global global_best_distance
    epoch = 0
    done = False
    
    while not done:
        
        # two condition to end this loop:
        # 1. the maximum number of epochs allowed has been reached or
        # 2. the Target value has been found.
        
        if epoch < MAX_EPOCHS:
            
            if global_best_distance < particles[0].get_p_best():
                global_best_distance = particles[0].get_p_best()
                print("{:10} {:25} {:5} {:10}".format(str(epoch), str(global_best_distance), str(particles[0].hand_off_count()), particles[0].hand_off_sequence()))             
    
            update_particles()
            bubble_sort()
            get_velocity()
            
            epoch += 1
        else:
            done = True
            
    print("{:10} {:25} {:5} {:10}".format(str(epoch), str(global_best_distance), str(particles[0].hand_off_count()), particles[0].hand_off_sequence()))             
        


# In[13]:


def main():
    initialize()
    pso_algorithm()
    print_best_solution()


# In[14]:


main()

