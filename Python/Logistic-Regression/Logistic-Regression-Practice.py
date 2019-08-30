
# coding: utf-8

# In[31]:


import pandas as pd 
import numpy as np
import seaborn as sns
import cufflinks as cf
import matplotlib.pyplot as plt
get_ipython().run_line_magic('matplotlib', 'inline')
cf.go_offline()


# In[86]:


train = pd.read_csv('titanic_train.csv')


# In[87]:


train.head()


# **
# Visualizing Data
# **

# In[10]:


sns.set_style('whitegrid')


# In[11]:


sns.heatmap(train.isnull(), cmap='viridis', yticklabels=False, cbar=False)


# In[18]:


sns.countplot(x = 'Survived', data = train, hue='Pclass')


# In[24]:


sns.distplot(train['Age'].dropna(), kde=False, bins = 30)


# In[25]:


train.info()


# In[28]:


sns.countplot(train['SibSp'])


# In[35]:


train['Fare'].iplot(kind='hist', bins=30)


# **
# Cleaning Data
# **

# In[59]:


# need to replace missing age value
# we can do it by replacing null value by its average value and to get accurate value of age, we can get categorize data by class
plt.figure(figsize=(10,7))
sns.boxplot(x = 'Pclass', y='Age', data = train)
print('Average age of people in class 1: ', int(train[train['Pclass'] == 1]['Age'].mean()))
print('Average age of people in class 2: ', int(train[train['Pclass'] == 2]['Age'].mean()))
print('Average age of people in class 3: ', int(train[train['Pclass'] == 3]['Age'].mean()))


# In[89]:


def impute_age(cols):
    Age = cols[0]
    Pclass = cols[1]
    
    if pd.isnull(Age):
        
        if Pclass == 1:
            return int(train[train['Pclass'] == 1]['Age'].mean())
        elif Pclass == 2:
            return int(train[train['Pclass'] == 2]['Age'].mean())
        else:
            return int(train[train['Pclass'] == 3]['Age'].mean())
        
    else:
        return Age


# In[90]:


# replaces all missing value in age
train['Age'] = train[['Age', 'Pclass']].apply(impute_age, axis = 1)


# In[91]:


sns.heatmap(train.isnull(), cbar=False, cmap='viridis', yticklabels=False)


# In[92]:


# dropped cabin column as it is not feasible to replace values due to many missing values
train.drop('Cabin', axis=1,inplace = True)


# In[93]:


sns.heatmap(train.isnull(), cbar=False, cmap='viridis', yticklabels=False)


# In[94]:


# dropping any other minor number of missing values
train.dropna(inplace=True)


# In[95]:


sns.heatmap(train.isnull(), cbar=False, cmap='viridis', yticklabels=False)


# In[98]:


# converting categories in numerical or binary values
sex = pd.get_dummies(train['Sex'],drop_first=True)


# In[102]:


embark = pd.get_dummies(train['Embarked'], drop_first=True)


# In[105]:


# adding new columns to original train data
train = pd.concat([train, sex, embark], axis = 1)


# In[109]:


train.head()


# In[117]:


train.drop(['Sex', 'Ticket', 'Name', 'Embarked'], axis = 1, inplace=True)


# In[115]:


train.head()


# In[118]:


train.drop('PassengerId', axis=1, inplace=True)


# In[119]:


train.head()

