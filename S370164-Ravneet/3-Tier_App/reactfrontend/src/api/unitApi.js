import axiosInstance from './axiosInstance';

export const getAllUnits= () => {
  return axiosInstance.get('/unit');
};

export const createUnit = (unitData) => {
  return axiosInstance.post('/unit', unitData);
};

export const updateUnit = (id, unitData) => {
  return axiosInstance.put(`/unit/${id}`, unitData);
};

export const deleteUnit = (id) => {
  return axiosInstance.delete(`/unit/${id}`);
};
