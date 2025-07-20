# flaskjinjapy2
# FlaskJinjaPy

## Launching the Flask Application

1. **Create and activate a virtual environment**  
    It's recommended to use a virtual environment to manage dependencies.  
    On Linux/macOS:
    ```
    python3 -m venv venv
    source venv/bin/activate
    ```
    On Windows:
    ```
    python -m venv venv
    venv\Scripts\activate
    ```

2. **Install dependencies**  
    Make sure you have Python and pip installed. Then run:
    ```
    pip install flask
    ```

3. **Set the FLASK_APP environment variable**  
    On Linux/macOS:
    ```
    export FLASK_APP=app.py
    ```
    On Windows:
    ```
    set FLASK_APP=app.py
    ```

4. **Run the Flask application**  
    ```
    flask run
    ```

5. **Access the app**  
    Open your browser and go to: [http://127.0.0.1:5000](http://127.0.0.1:5000)

## Notes

- Replace `app.py` with your main Flask file if it's named differently.
- For development, you can enable debug mode:
  ```
  export FLASK_ENV=development
  ```