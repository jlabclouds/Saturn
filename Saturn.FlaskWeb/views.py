"""
Routes and views for the flask application.
"""

from datetime import datetime
from flask import render_template
from FlaskJinjaPy import app
from flask import request, jsonify

@app.route('/')
@app.route('/home')
def home():
    """Renders the home page."""
    return render_template(
        'index.html',
        title='Home Page',
        year=datetime.now().year,
    )

@app.route('/contact')
def contact():
    """Renders the contact page."""
    return render_template(
        'contact.html',
        title='Contact',
        year=datetime.now().year,
        message='Your contact page.'
    )

@app.route('/about')
def about():
    """Renders the about page."""
    return render_template(
        'about.html',
        title='About',
        year=datetime.now().year,
        message='Your application description page.'
    )

@app.route('/login', methods=['GET', 'POST'])
def login():
    if request.method == 'POST':
        data = request.get_json() or request.form
        username = data.get('username')
        password = data.get('password')
        # Authenticate user here
        if username == 'admin' and password == 'secret':
            return jsonify({'success': True}), 200
        return jsonify({'success': False}), 401
    # For GET requests, render the login popup template
    return render_template(
        'login.html',
        title='Login',
        year=datetime.now().year
    )
