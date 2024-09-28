import './App.css';
import { BrowserRouter as Router, Route, Routes } from 'react-router-dom';
import HomePage from './pages/HomePage';
import AddStudentForm from './pages/AddStudentForm';

 
function App() {

    return (
        <Router>
            <Routes>
                <Route path="/" element={<HomePage />} />
                <Route path="/add-student" element={<AddStudentForm />} />
            </Routes>
        </Router >
    );
}

export default App;