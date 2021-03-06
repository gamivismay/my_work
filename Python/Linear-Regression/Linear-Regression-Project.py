
# coding: utf-8

# ___
# 
# <a href='http://vismaygami.com/'> <img src='http://vismaygami.com/img/profile.png' width=350 /></a>
# ___
# 
# # Linear Regression - Project Exercise
# 
# Congratulations! You just got some contract work with an Ecommerce company based in New York City that sells clothing online but they also have in-store style and clothing advice sessions. Customers come in to the store, have sessions/meetings with a personal stylist, then they can go home and order either on a mobile app or website for the clothes they want.
# 
# The company is trying to decide whether to focus their efforts on their mobile app experience or their website. They've hired you on contract to help them figure it out! Let's get started!

# ## Imports
# ** Import pandas, numpy, matplotlib,and seaborn. Then set %matplotlib inline 
# (You'll import sklearn as you need it.)**

# In[2]:


import pandas as pd
import numpy as np
import seaborn as sns
import matplotlib.pyplot as plt

get_ipython().run_line_magic('matplotlib', 'inline')


# ## Get the Data
# 
# We'll work with the Ecommerce Customers csv file from the company. It has Customer info, suchas Email, Address, and their color Avatar. Then it also has numerical value columns:
# 
# * Avg. Session Length: Average session of in-store style advice sessions.
# * Time on App: Average time spent on App in minutes
# * Time on Website: Average time spent on Website in minutes
# * Length of Membership: How many years the customer has been a member. 
# 
# ** Read in the Ecommerce Customers csv file as a DataFrame called customers.**

# In[7]:


ecommerce_customers = pd.read_csv('Ecommerce Customers.csv')


# **Check the head of customers, and check out its info() and describe() methods.**

# In[8]:


ecommerce_customers.head()


# In[10]:


ecommerce_customers.describe()


# In[11]:


ecommerce_customers.info()


# ## Exploratory Data Analysis
# 
# **Let's explore the data!**
# 
# For the rest of the exercise we'll only be using the numerical data of the csv file.
# ___
# **Use seaborn to create a jointplot to compare the Time on Website and Yearly Amount Spent columns. Does the correlation make sense?**

# In[13]:


sns.set_palette("GnBu_d")
sns.set_style('whitegrid')


# In[15]:


sns.jointplot(x='Time on Website', y='Yearly Amount Spent', data=ecommerce_customers)


# ** Do the same but with the Time on App column instead. **

# In[16]:


sns.jointplot(x='Time on App', y='Yearly Amount Spent', data=ecommerce_customers)


# ** Use jointplot to create a 2D hex bin plot comparing Time on App and Length of Membership.**

# In[22]:


sns.jointplot(x='Time on App',y='Length of Membership',kind='hex',data=ecommerce_customers)


# **Let's explore these types of relationships across the entire data set. Use [pairplot](https://stanford.edu/~mwaskom/software/seaborn/tutorial/axis_grids.html#plotting-pairwise-relationships-with-pairgrid-and-pairplot) to recreate the plot below.

# In[23]:


sns.pairplot(ecommerce_customers)


# **Based off this plot what looks to be the most correlated feature with Yearly Amount Spent?**

# In[24]:


# Length of Membership


# **Create a linear model plot (using seaborn's lmplot) of  Yearly Amount Spent vs. Length of Membership. **

# In[25]:


sns.lmplot(x = 'Length of Membership', y = 'Yearly Amount Spent', data = ecommerce_customers)


# ## Training and Testing Data
# 
# Now that we've explored the data a bit, let's go ahead and split the data into training and testing sets.
# ** Set a variable X equal to the numerical features of the customers and a variable y equal to the "Yearly Amount Spent" column. **

# In[26]:


ecommerce_customers.columns


# In[52]:


X = ecommerce_customers[['Avg. Session Length', 'Time on App', 'Time on Website', 'Length of Membership']]
X.head()


# In[53]:


y = ecommerce_customers['Yearly Amount Spent']
y.head()


# ** Use model_selection.train_test_split from sklearn to split the data into training and testing sets. Set test_size=0.3 and random_state=101**

# In[35]:


from sklearn.model_selection import train_test_split


# In[54]:


X_train, X_test, y_train, y_test = train_test_split(X, y, test_size = 0.3, random_state = 101)


# ## Training the Model
# 
# Now its time to train our model on our training data!
# 
# ** Import LinearRegression from sklearn.linear_model **

# In[46]:


from sklearn.linear_model import LinearRegression


# **Create an instance of a LinearRegression() model named lm.**

# In[47]:


lm = LinearRegression()


# ** Train/fit lm on the training data.**

# In[55]:


lm.fit(X_train, y_train)


# **Print out the coefficients of the model**

# In[61]:


print('Coefficeints:\n', lm.coef_)


# ## Predicting Test Data
# Now that we have fit our model, let's evaluate its performance by predicting off the test values!
# 
# ** Use lm.predict() to predict off the X_test set of the data.**

# In[71]:


predictions = lm.predict(X_test)


# ** Create a scatterplot of the real test values versus the predicted values. **

# In[73]:


plt.scatter(y_test,predictions,c='blue')
plt.xlabel('Y Test')
plt.ylabel('Predicted Y')


# ## Evaluating the Model
# 
# Let's evaluate our model performance by calculating the residual sum of squares and the explained variance score (R^2).
# 
# ** Calculate the Mean Absolute Error, Mean Squared Error, and the Root Mean Squared Error. Refer to the lecture or to Wikipedia for the formulas**

# In[75]:


from sklearn import metrics


# In[87]:


print('MAE:', metrics.mean_absolute_error(y_test, predictions))
print('MSE:', metrics.mean_squared_error(y_test, predictions))
print('RMSE:', np.sqrt(metrics.mean_squared_error(y_test, predictions)))
print('Variance:', metrics.explained_variance_score(y_test, predictions))


# ## Residuals
# 
# You should have gotten a very good model with a good fit. Let's quickly explore the residuals to make sure everything was okay with our data. 
# 
# **Plot a histogram of the residuals and make sure it looks normally distributed. Use either seaborn distplot, or just plt.hist().**

# In[83]:


plt.hist(y_test-predictions, bins=50)


# In[82]:


sns.distplot(y_test-predictions, bins=50)


# ## Conclusion
# We still want to figure out the answer to the original question, do we focus our efforst on mobile app or website development? Or maybe that doesn't even really matter, and Membership Time is what is really important.  Let's see if we can interpret the coefficients at all to get an idea.
# 
# ** Recreate the dataframe below. **

# In[85]:


pd.DataFrame(lm.coef_, X.columns, columns=['Coefficient'])


# ** How can you interpret these coefficients? **

# Interpreting the coefficients:
# 
# - Holding all other features fixed, a 1 unit increase in **Avg. Session Length** is associated with an **increase of 25.98 total dollars spent**.
# - Holding all other features fixed, a 1 unit increase in **Time on App** is associated with an **increase of 38.59 total dollars spent**.
# - Holding all other features fixed, a 1 unit increase in **Time on Website** is associated with an **increase of 0.19 total dollars spent**.
# - Holding all other features fixed, a 1 unit increase in **Length of Membership** is associated with an **increase of 61.27 total dollars spent**.

# **Do you think the company should focus more on their mobile app or on their website?**

# 
# This is tricky, there are two ways to think about this: Develop the Website to catch up to the performance of the mobile app, or develop the app more since that is what is working better. This sort of answer really depends on the other factors going on at the company, you would probably want to explore the relationship between Length of Membership and the App or the Website before coming to a conclusion!
# 
