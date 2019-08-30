
# coding: utf-8

# In[1]:


import random
import math


# In[2]:


PERIODS = 40
PARTICLE_COUNT = 20
V_MIN = -4
V_MAX = 4
NET_REQUIREMENT_R = [100,60,40,50,80,70,40,50,80,70,100,60,40,50,80,70,40,50,80,70,100,60,40,50,80,70,40,50,80,70,100,60,40,50,80,70,40,50,80,70]
C_VALUE = 1.0
A_VALUE = 100.0
global_best = 0.0
C1 = 0.5
C2 = 0.5
MAX_EPOCHS = 10000
epoch = 0
particles = []


# In[3]:


class Particle:
    
    def __init__(self):
        self.m_data = [0] * PERIODS
        self.velocity = [0] * PERIODS
        self.sigmoidv = [0] * PERIODS
        self.mp_best = [0] * PERIODS
        self.projected_i = [0] * PERIODS
        self.order_qty_q = [0] * PERIODS
    
    def update_current_cost(self):
        for i in range(PERIODS):
            self.order_qty_q[i] = 0
            
        current_index = 0
        for i in range(PERIODS):
            if self.m_data[i] == 1:
                current_index = i
            self.order_qty_q[current_index] += NET_REQUIREMENT_R[i]
        
        for i in range(PERIODS):
            if i > 0:
                self.projected_i[i] = self.projected_i[i-1] + self.m_data[i] * self.order_qty_q[i] - NET_REQUIREMENT_R[i]
            else:
                self.projected_i[i] = self.m_data[i] * self.order_qty_q[i] - NET_REQUIREMENT_R[i]
        
        current_cost = 0.0
        for i in range(PERIODS):
            current_cost += A_VALUE * self.m_data[i] + C_VALUE * self.projected_i[i]
            
        if current_cost < 0:
            return current_cost
        
        return current_cost
    

    def set_current_best(self,cost):
        self.current_best = cost
        
    def get_current_best(self):
        return self.current_best
        
    def set_current_cost(self,cost):
        self.current_cost = cost
    
    def get_current_cost(self):
        return self.current_cost
        
    def get_data(self,index):
        return self.m_data[index]

    def set_data(self,index,value):
        self.m_data[index] = value
        
    def get_p_best(self, index):
        return self.mp_best[index]
    
    def set_p_best(self,index,value):
        self.mp_best[index] = value
    
    def get_velocity(self, index):
        return self.velocity[index]
    
    def set_velocity(self,index, value):
        self.velocity[index] = value
    
        


# In[4]:


global_particle = Particle()


# In[5]:


def initialize():
    global global_particle
    global global_best
    
    for i in range(PARTICLE_COUNT):
        new_particle = Particle()
        for j in range(PERIODS):
            if j == 0:
                new_particle.set_data(j,1)
            else:
                new_particle.set_data(j,int(random.random() + 0.5))
            new_particle.set_p_best(j, new_particle.get_data(j))
            new_particle.set_velocity(j, V_MIN + ((V_MAX-V_MIN) * random.random()))
        
        particles.append(new_particle)
        current_cost = new_particle.update_current_cost()
        new_particle.set_current_best(current_cost)
        
        if i == 0:
            global_best = current_cost
            global_particle = new_particle
        else:
            if global_best > current_cost:
                global_best = current_cost
                global_particle = new_particle
    print("{:15} {:10}".format("Iteration","Cost"))    
    print("{:15} {:10}".format(str(epoch),str(global_best)))


# In[6]:


def update_particles():
    global global_particle
    global global_best
    
    for i in range(PARTICLE_COUNT):
        #particle = Particle()
        particle = particles[i]
        
        for j in range(PERIODS):
            deltav = C1 * random.random() * (particle.mp_best[j] - particle.m_data[j]) + C2 * random.random() * (global_particle.mp_best[j] - particle.m_data[j]) 
            v = particle.get_velocity(j) + deltav
            particle.set_velocity(j,v)
            
            sigmoidv = 1 / (1 + math.expm1(-v) + 1)
            particle.sigmoidv[j] = sigmoidv
            
            if j != 0:
                temp = random.random()
                if temp < sigmoidv:
                    particle.m_data[j] = 1
                elif temp > sigmoidv:
                    particle.m_data[j] = 0
                    
        current_cost = particle.update_current_cost()
        if current_cost < particle.current_best:
            particle.set_current_best(current_cost)
            particle.mp_best = particle.m_data
            #print(current_cost, global_best, particle.current_best)
            # print(f"{epoch}\t{global_best}")            
            
            
        if global_best > particle.current_best:
            global_best = particle.current_best
            global_particle = particle
            print("{:15} {:10}".format(str(epoch),str(global_best)))


# In[7]:


def main():
    global epoch
    global MAX_EPOCHS
    done = False
    initialize()
    while not done:
        if epoch > MAX_EPOCHS:
            done = True
            continue
        update_particles()
        epoch += 1
        
    print(f"{global_particle.mp_best}")    


# In[8]:


main()

