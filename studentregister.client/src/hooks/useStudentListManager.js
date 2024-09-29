import { useState, useEffect } from 'react';
import { useDispatch, useSelector } from 'react-redux';
import { fetchStudents } from '../features/StudentListSlice';
import { updateStudentNationality, createFamilyMember } from '../apis/studentApi';
import { updateFamilyMemberNationality } from "../apis/familymemberapi.js"

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

    const saveStudent = async (updatedStudent) => {
        console.log("Updated:", updatedStudent);
        updateStudentNationality(updatedStudent.id, updatedStudent.nationalityId);

        if (updatedStudent.familyMembers && updatedStudent.familyMembers.length > 0) {
            updatedStudent.familyMembers.map((fm) => {
                AddNewFamilyMember(updatedStudent.id, fm);
                console.log(fm); // Example: Logging each family member
            });
        }
        
        closeModal();
    };

    const AddNewFamilyMember = async (studentId, familyMember) => {
        const data = await createFamilyMember(studentId, familyMember);
        await updateFamilyMemberNationality(data.id, familyMember.nationalityId);
    }

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
