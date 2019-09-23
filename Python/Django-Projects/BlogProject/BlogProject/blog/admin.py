from django.contrib import admin
from blog.models import Post, Comment
from blog.forms import PostForm, CommentForm

# Register your models here.
admin.site.register(Post)
admin.site.register(Comment)
