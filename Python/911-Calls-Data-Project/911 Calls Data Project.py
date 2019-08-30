
# coding: utf-8

# ____
# <a href="http://vismaygami.com/"><img src="http://vismaygami.com/img/profile.png" width="350"></a>
# ____
# 

# # 911 Calls Capstone Project

# For this capstone project we will be analyzing some 911 call data from [Kaggle](https://www.kaggle.com/mchirico/montcoalert). The data contains the following fields:
# 
# * lat : String variable, Latitude
# * lng: String variable, Longitude
# * desc: String variable, Description of the Emergency Call
# * zip: String variable, Zipcode
# * title: String variable, Title
# * timeStamp: String variable, YYYY-MM-DD HH:MM:SS
# * twp: String variable, Township
# * addr: String variable, Address
# * e: String variable, Dummy variable (always 1)

# ## Data and Setup

# ____
# ** Import numpy and pandas **

# In[1]:


import numpy as np
import pandas as pd


# ** Import visualization libraries and set %matplotlib inline. **

# In[26]:


import matplotlib.pyplot as plt
import seaborn as sns
sns.set_style('whitegrid')
get_ipython().run_line_magic('matplotlib', 'inline')


# ** Read in the csv file as a dataframe called df **

# In[4]:


df = pd.read_csv("911.csv")


# ** Check the info() of the df **

# In[7]:


df.info()


# ** Check the head of df **

# In[9]:


df.head(3)


# ** What are the top 5 zipcodes for 911 calls? **

# In[33]:


df['zip'].value_counts().head()


# ** What are the top 5 townships (twp) for 911 calls? **

# In[36]:


df['twp'].value_counts().head()


# ** Take a look at the 'title' column, how many unique title codes are there? **

# In[41]:


df['title'].nunique()


# ## Creating new features

# ** In the titles column there are "Reasons/Departments" specified before the title code. These are EMS, Fire, and Traffic. Use .apply() with a custom lambda expression to create a new column called "Reason" that contains this string value.** 
# 
# **For example, if the title column value is EMS: BACK PAINS/INJURY , the Reason column value would be EMS. **

# In[101]:


df['Reason'] = df['title'].apply(lambda title: title.split(':')[0])
df['Reason'].head()


# ** What is the most common Reason for a 911 call based off of this new column? **

# In[51]:


df['Reason'].value_counts()


# ** Now use seaborn to create a countplot of 911 calls by Reason. **

# In[59]:


sns.countplot(x='Reason', data=df, palette='viridis')


# ___
# ** Now let us begin to focus on time information. What is the data type of the objects in the timeStamp column? **

# In[71]:


type(df['timeStamp'].iloc[0])


# ** You should have seen that these timestamps are still strings. Use [pd.to_datetime](http://pandas.pydata.org/pandas-docs/stable/generated/pandas.to_datetime.html) to convert the column from strings to DateTime objects. **

# In[102]:


df['timeStamp'] = pd.to_datetime(df['timeStamp'])


# In[155]:


df['timeStamp'].head()


# ** You can now grab specific attributes from a Datetime object by calling them. For example:**
# 
#     time = df['timeStamp'].iloc[0]
#     time.hour
# 
# **You can use Jupyter's tab method to explore the various attributes you can call. Now that the timestamp column are actually DateTime objects, use .apply() to create 3 new columns called Hour, Month, and Day of Week. You will create these columns based off of the timeStamp column, reference the solutions if you get stuck on this step.**

# In[103]:


df['Hour'] = df['timeStamp'].apply(lambda time: time.hour)
df['Month'] = df['timeStamp'].apply(lambda time: time.month)
df['Day of Week'] = df['timeStamp'].apply(lambda time: time.dayofweek)


# ** Notice how the Day of Week is an integer 0-6. Use the .map() with this dictionary to map the actual string names to the day of the week: **
# 
#     dmap = {0:'Mon',1:'Tue',2:'Wed',3:'Thu',4:'Fri',5:'Sat',6:'Sun'}

# In[104]:


dmap = {0:'Mon',1:'Tue',2:'Wed',3:'Thu',4:'Fri',5:'Sat',6:'Sun'}


# In[105]:


df['Day of Week'] = df['Day of Week'].map(dmap)
df.head()


# ** Now use seaborn to create a countplot of the Day of Week column with the hue based off of the Reason column. **

# In[107]:


sns.countplot(x='Day of Week',data=df,hue='Reason',palette='viridis')
plt.legend(bbox_to_anchor=(1.05, 1), loc=2, borderaxespad=0.)


# **Now do the same for Month:**

# In[108]:


sns.countplot(x='Month',data=df,hue='Reason',palette='viridis')
plt.legend(bbox_to_anchor=(1.05, 1), loc=2, borderaxespad=0.)


# **Did you notice something strange about the Plot?**
# 
# _____
# 
# ** You should have noticed it was missing some Months, let's see if we can maybe fill in this information by plotting the information in another way, possibly a simple line plot that fills in the missing months, in order to do this, we'll need to do some work with pandas... **

# ** Now create a gropuby object called byMonth, where you group the DataFrame by the month column and use the count() method for aggregation. Use the head() method on this returned DataFrame. **

# In[112]:


by_month = df.groupby('Month').count()


# In[115]:


by_month.head()


# ** Now create a simple plot off of the dataframe indicating the count of calls per month. **

# In[120]:


by_month['twp'].plot()


# ** Now see if you can use seaborn's lmplot() to create a linear fit on the number of calls per month. Keep in mind you may need to reset the index to a column. **

# In[123]:


sns.lmplot(x = 'Month', y = 'twp', data = by_month.reset_index())


# **Create a new column called 'Date' that contains the date from the timeStamp column. You'll need to use apply along with the .date() method. ** 

# In[126]:


df['Date'] = df['timeStamp'].apply(lambda t : t.date())
df['Date'].head()


# ** Now groupby this Date column with the count() aggregate and create a plot of counts of 911 calls.**

# In[133]:


df.groupby('Date').count()['twp'].plot()
plt.tight_layout()


# ** Now recreate this plot but create 3 separate plots with each plot representing a Reason for the 911 call**

# In[135]:


df[df['Reason'] == 'Traffic'].groupby('Date').count()['twp'].plot()
plt.title('Traffic')
plt.tight_layout()


# In[136]:


df[df['Reason'] == 'Fire'].groupby('Date').count()['twp'].plot()
plt.title('Fire')
plt.tight_layout()


# In[137]:


df[df['Reason'] == 'EMS'].groupby('Date').count()['twp'].plot()
plt.title('EMS')
plt.tight_layout()


# ____
# ** Now let's move on to creating  heatmaps with seaborn and our data. We'll first need to restructure the dataframe so that the columns become the Hours and the Index becomes the Day of the Week. There are lots of ways to do this, but I would recommend trying to combine groupby with an [unstack](http://pandas.pydata.org/pandas-docs/stable/generated/pandas.DataFrame.unstack.html) method. Reference the solutions if you get stuck on this!**

# In[140]:


dayHour = df.groupby(by=['Day of Week','Hour']).count()['Reason'].unstack()
dayHour.head()


# ** Now create a HeatMap using this new DataFrame. **

# In[145]:


plt.figure(figsize=(12,8))
sns.heatmap(dayHour,cmap='viridis')


# ** Now create a clustermap using this DataFrame. **

# In[146]:


sns.clustermap(dayHour,cmap='viridis')


# ** Now repeat these same plots and operations, for a DataFrame that shows the Month as the column. **

# In[151]:


dayMonth = df.groupby(['Day of Week', 'Month']).count()['Reason'].unstack()
dayMonth.head()


# In[152]:


plt.figure(figsize=(12,6))
sns.heatmap(dayMonth,cmap='viridis')


# In[153]:


sns.clustermap(dayMonth,cmap='viridis')

