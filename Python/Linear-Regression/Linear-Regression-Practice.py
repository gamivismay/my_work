
# coding: utf-8

# In[3]:


import pandas as pd
import numpy as np
import seaborn as sns
import matplotlib.pyplot as plt

get_ipython().run_line_magic('matplotlib', 'inline')


# In[22]:


from sklearn.model_selection import train_test_split
from sklearn.linear_model import LinearRegression


# In[4]:


df = pd.read_csv('USA_Housing.csv')


# In[6]:


df.head()


# In[7]:


df.info()


# In[8]:


df.describe()


# In[9]:


sns.pairplot(df)


# In[10]:


df.columns


# In[17]:


X = df[['Avg. Area Income', 'Avg. Area House Age', 'Avg. Area Number of Rooms',
       'Avg. Area Number of Bedrooms', 'Area Population']]


# In[18]:


y = df['Price']


# In[19]:


train_test_split


# In[21]:


X_train, X_test, y_train, y_test = train_test_split(X, y, test_size=0.4, random_state=101)


# In[24]:


lm = LinearRegression()


# In[26]:


lm.fit(X_train, y_train)


# In[27]:


print(lm.intercept_)


# In[28]:


lm.coef_


# In[29]:


cdf = pd.DataFrame(lm.coef_, X.columns, columns=['Coeff'])


# In[30]:


cdf


# In[31]:


from sklearn.datasets import load_boston


# In[32]:


boston = load_boston()


# In[40]:


print(boston['feature_names'])


# In[47]:


predictions = lm.predict(X_test)


# In[50]:


plt.scatter(y_test, predictions)


# In[51]:


sns.distplot(y_test-predictions)


# In[52]:


from sklearn import metrics


# In[53]:


metrics.mean_absolute_error(y_test, predictions)


# In[54]:


metrics.mean_squared_error(y_test, predictions)


# In[55]:


np.sqrt(metrics.mean_squared_error(y_test, predictions))

