
# coding: utf-8

# <h1>Python script to send emails.</h1>

# <h2>Send simple text emails</h2>

# In[1]:


# import smtplib for sending email
import smtplib

# import email modules that we will need
from email.mime.text import MIMEText

# sender's email address
sender = "info@vismaygami.com"

# recipient's email address
receiver = "gamivismaytesting@gmail.com"

# configuring mail details
message = MIMEText("This is a test mail")
message['Subject'] = "Testing"
message['From'] = sender
message['To'] = receiver
# msg['password'] = "Info@vismaygami"

try:
    send = smtplib.SMTP('smtpout.secureserver.net','80')
    send.login('info@vismaygami.com','Info@vismaygami')
    send.sendmail(sender, [receiver],message.as_string())
    send.quit()
    print("Successfully sent email.")
except:
    print("Error: unable to send email.")


# <h2>Send HTML emails</h2>

# In[2]:


# import smtplib for sending email
import smtplib

# sender's email address
sender = "info@vismaygami.com"

# recipient's email address
receiver = "gamivismaytesting@gmail.com"

# configuring message content details
message = """From: HTML Mail Testing <info@vismaygami.com>
To: To Person <gamivismaytesting@gmail.com>
MIME-Version: 1.0
Content-type: text/html
Subject: SMTP HTML e-mail test

This is an e-mail message to be sent in HTML format
<br>
<b>This is HTML message.</b>
<h1>This is headline.</h1>
"""

try:
    send = smtplib.SMTP('smtpout.secureserver.net','80')
    send.login('info@vismaygami.com','Info@vismaygami')
    send.sendmail(sender, [receiver], message)
    send.quit()
    print("Successfully sent email.")
except:
    print("Error: unable to send email.")


# <h2>Send emails with attachments</h2>

# In[3]:


#!/usr/bin/python

import smtplib
import base64

filename = "hello.txt"

# Read a file and encode it into base64 format
fo = open(filename, "rb")
filecontent = fo.read()
encodedcontent = base64.b64encode(filecontent)  # base64

sender = 'info@vismaygami.com'
reciever = 'gamivismaytesting@gmail.com'

marker = "AUNIQUEMARKER"

body ="""
This is a test email to send an attachement.
"""
# Define the main headers.
part1 = """From: From Person <me@fromdomain.net>
To: To Person <amrood.admin@gmail.com>
Subject: Sending Attachement
MIME-Version: 1.0
Content-Type: multipart/mixed; boundary=%s
--%s
""" % (marker, marker)

# Define the message action
part2 = """Content-Type: text/plain
Content-Transfer-Encoding:8bit

%s
--%s
""" % (body,marker)

# Define the attachment section
part3 = """Content-Type: multipart/mixed; name=\"%s\"
Content-Transfer-Encoding:base64
Content-Disposition: attachment; filename=%s

%s
--%s--
""" %(filename, filename, encodedcontent, marker)
message = part1 + part2 + part3

try:
    smtpObj = smtplib.SMTP('smtpout.secureserver.net','80')
    smtpObj.login('info@vismaygami.com','Info@vismaygami')
    smtpObj.sendmail(sender, reciever, message)
    print("Successfully sent email")
except Exception:
    print("Error: unable to send email")

