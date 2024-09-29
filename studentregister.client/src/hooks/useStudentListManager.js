import { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchStudents } from '../features/StudentListSlice';
import { updateStudentNationality } from '../apis/studentApi';

const useStudentListManager = () => {
    const dispatch = useDispatch();
    const students = useSelector((state) => state.students.students);
    const status = useSelector((state) => state.students.status);
    const error = useSelector((state) => state.students.error);

    const [selectedStudent, setSelectedStudent] = useState(null);
    const [isModalOpen, setIsModalOpen] = useState(false);

    useEffect(() => {
        if (status === 'idle') {
            dispatch(fetchStudents());
        }
    }, [status, dispatch]);

    const openModal = (student) => {
        setSelectedStudent(student);
        setIsModalOpen(true);
    };

    const closeModal = () => {
        setSelectedStudent(null);
        setIsModalOpen(false);
    };

    const saveStudent = (updatedStudent) => {
        updateStudentNationality(updatedStudent.id, updatedStudent.nationalityId);
        // Add additional update logic if needed
        closeModal();
    };

    return {
        students,
        status,
        error,
        selectedStudent,
        isModalOpen,
        openModal,
        closeModal,
        saveStudent,
    };
};

export default useStudentListManager;
