<script lang="ts" setup>
import { reactive, ref, h } from "vue";
import { getPageList, deleteData } from "@/api/asset/assetList";
import { ReVxeGrid } from "@/components/ReVxeTable";
import CreateModal from "./CreateModal.vue";
import { VxeTag, VxeUI } from "vxe-pc-ui";
const reVxeGridRef = ref();
const columns = [
  { type: "checkbox", title: "", width: 60, align: "center" },
  {
    title: "资产编号",
    field: "assetId",
    minWidth: 160
  },
  {
    title: "资产名称",
    field: "assetName",
    minWidth: 150
  },
  {
    title: "类型",
    field: "assetTypeName",
    minWidth: 80
  },
  {
    title: "品牌",
    field: "assetBrand",
    minWidth: 100
  },
  {
    title: "型号",
    field: "assetModel",
    minWidth: 100
  },
  {
    title: "系类",
    field: "assetSeries",
    minWidth: 100
  },
  {
    title: "TAG",
    field: "serverTag",
    minWidth: 100
  },
  {
    title: "用户",
    field: "assignUserName",
    minWidth: 80
  },
  {
    title: "状态",
    field: "assetStatus",
    minWidth: 100,
    slots: {
      default: ({ row }) => getStatusTag(row.assetStatus)
    }
  },
  {
    title: "保质期",
    field: "warranty",
    minWidth: 50
  },
  {
    title: "购买时间",
    field: "purchaseDate",
    minWidth: 200
  },
  {
    title: "备注",
    field: "remark",
    minWidth: 150
  },
  {
    title: "上一位用户",
    field: "lastUserName",
    minWidth: 100
  }
];
const formRef = ref();

const handleInitialFormParams = () => ({
  name: "",
  account: "",
  status: null
});
const formItems = [
  {
    field: "assetId",
    title: "资产编号",
    span: 6,
    itemRender: { name: "$input", props: { placeholder: "资产编号" } }
  },
  {
    field: "assetStatus",
    title: "资产状态",
    span: 6,
    itemRender: {
      name: "$select",
      props: {
        options: [
          { label: "全部", value: null },
          { label: "报废", value: "0" },
          { label: "闲置", value: "1" },
          { label: "使用中", value: "2" },
          { label: "出售", value: "3" }
        ],
        placeholder: "资产状态"
      }
    }
  },
  {
    span: 6,
    itemRender: {
      name: "$buttons",
      children: [
        {
          props: {
            type: "submit",
            icon: "vxe-icon-search",
            content: "查询",
            status: "primary"
          }
        },
        { props: { type: "reset", icon: "vxe-icon-undo", content: "重置" } }
      ]
    }
  }
];
const formData = reactive<{
  name: string;
  account: string;
  status: number | null;
}>(handleInitialFormParams());

// 定义一个方法来根据状态生成标签
const getStatusTag = (status: number) => {
  const statusMap = {
    2: { label: "使用中", tagStatus: "success" },
    0: { label: "报废", tagStatus: "error" },
    1: { label: "闲置", tagStatus: "info" },
    3: { label: "出售", tagStatus: "primary" }
  };

  const { label, tagStatus } = statusMap[status] || {
    label: "未知",
    tagStatus: "default"
  };

  return h(
    VxeTag,
    {
      status: tagStatus,
      size: "mini"
    },
    { default: () => h("span", label) }
  );
};

const handleSearch = () => {
  reVxeGridRef.value.loadData();
};

const createModalRef = ref();
const handleAdd = () => {
  createModalRef.value.showAddModal();
};
const handleEdit = (record: Recordable) => {
  createModalRef.value.showEditModal(record);
};
const handleDelete = async (record: Recordable) => {
  const type = await VxeUI.modal.confirm("您确定要删除吗？");
  if (type == "confirm") {
    deleteData(record.id).then(() => {
      handleSearch();
    });
  }
};
const handleView = (record: Recordable) => {
  createModalRef.value.showViewModal(record);
};

const functions: Record<string, string> = {
  add: "system.user.add",
  edit: "system.user.edit",
  view: "system.user.view",
  delete: "system.user.delete"
};
</script>
<template>
  <div>
    <el-card :shadow="`never`">
      <vxe-form
        ref="formRef"
        :data="formData"
        :items="formItems"
        @submit="handleSearch"
        @reset="handleInitialFormParams"
      />
    </el-card>
    <el-card :shadow="`never`" class="table-card">
      <ReVxeGrid
        ref="reVxeGridRef"
        :request="getPageList"
        :functions="functions"
        :searchParams="formData"
        :columns="columns"
        @handleAdd="handleAdd"
        @handleEdit="handleEdit"
        @handleDelete="handleDelete"
        @handleView="handleView"
      />
    </el-card>
    <CreateModal ref="createModalRef" @reload="handleSearch" />
  </div>
</template>
