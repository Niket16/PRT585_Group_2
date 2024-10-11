import React, { useEffect, useState } from 'react';
import { getAllUnits, deleteUnit } from '../api/unitApi';

const UnitList = ({ onEdit }) => {
  const [units, setUnits] = useState([]);

  useEffect(() => {
    fetchUnits();
  }, []);

  const fetchUnits = async () => {
    const response = await getAllUnits();
    setUnits(response.data);
  };

  const handleDelete = async (id) => {
    await deleteUnit(id);
    fetchUnits();
  };

  return (
    <div>
      <h2>Unit List</h2>
      <ul>
        {units.map((unit) => (
          <li key={unit.id}>
            {unit.unitCode} - {unit.unitName}
            <button onClick={() => onEdit(unit)}>Edit</button>
            <button onClick={() => handleDelete(unit.id)}>Delete</button>
          </li>
        ))}
      </ul>
    </div>
  );
};

export default UnitList;
