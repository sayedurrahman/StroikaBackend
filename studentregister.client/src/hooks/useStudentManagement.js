import { useEffect, useState } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { addStudent } from '../features/addStudentSlice';
import { fetchStudents, refreshStudent } from '../features/StudentListSlice';
import { useNavigate } from 'react-router-dom';

const useStudentManagement = () => {
    const dispatch = useDispatch();
    const navigate = useNavigate();
    const studentStatus = useSelector((state) => state.students.status);

    const [firstName, setFirstName] = useState('');
    const [lastName, setLastName] = useState('');
    const [dob, setDob] = useState(new Date().toISOString().substring(0, 10)); // Set initial date to today

    // Student list refresh: Fetch students when status is idle
    useEffect(() => {
        if (studentStatus === 'idle') {
            dispatch(fetchStudents());
        }
    }, [studentStatus, dispatch]);

    // Student list refresh: Update status
    const handleStudentListRefresh = () => {
        dispatch(refreshStudent());
    };

    // Handle form submission
    const handleAddStudentSubmit = async (e) => {
        e.preventDefault(); // Prevent page refresh
        const student = {
            firstName,
            lastName,
            dateOfBirth: dob,
        };

        try {
            // Dispatch the createAsyncThunk to add the student
            await dispatch(addStudent(student)).unwrap(); // Ensure the action is completed
            handleStudentListRefresh(); // Refresh the student list
            navigate('/'); // Redirect to the home page
        } catch (error) {
            console.error('Failed to add student:', error);
        }
    };

    // Reset form fields
    const handleReset = () => {
        setFirstName('');
        setLastName('');
        setDob(new Date().toISOString().substring(0, 10)); // Reset to today
    };

    const navigateToHome = () => navigate('/');

    return {
        firstName,
        lastName,
        dob,
        setFirstName,
        setLastName,
        setDob,
        handleAddStudentSubmit,
        handleReset,
        handleStudentListRefresh,
        navigateToHome,
    };
};

export default useStudentManagement;
